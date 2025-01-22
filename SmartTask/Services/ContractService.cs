using SmartTask.Db;
using SmartTask.Entities;
using Microsoft.EntityFrameworkCore;
using SmartTask.Models.Contract.Create;
using SmartTask.Models.Contract.Get;

namespace SmartTask.Services
{
    public class ContractService : IContractService
    {
        private readonly AppDbContext _context;

        public ContractService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ContractResponse>> GetContractsAsync()
        {
            return await _context.EquipmentPlacementContracts
                .Include(c => c.ProductionFacility)
                .Include(c => c.ProcessEquipmentType)
                .Select(c => new ContractResponse
                {
                    ProductionFacilityName = c.ProductionFacility.Name,
                    ProcessEquipmentTypeName = c.ProcessEquipmentType.Name,
                    Quantity = c.EquipmentQuantity
                })
                .ToListAsync();
        }

        public async Task<CreateContractResponse> CreateContractAsync(CreateContractRequest request)
        {
                var facility = await _context.ProductionFacilities.FirstOrDefaultAsync(f => f.Id == request.ProductionFacilityId);
                if (facility == null)
                {
                    throw new Exception("Production facility not found.");
                }

                var equipmentType = await _context.ProcessEquipmentTypes.FirstOrDefaultAsync(e => e.Id == request.ProcessEquipmentTypeId);
                if (equipmentType == null)
                {
                    throw new Exception("Process equipment type not found.");
                }

                var requiredArea = equipmentType.Area * request.Quantity;
                var usedArea = await _context.EquipmentPlacementContracts
                    .Where(c => c.ProductionFacilityId == facility.Id)
                    .SumAsync(c => c.EquipmentQuantity * c.ProcessEquipmentType.Area);

                if (usedArea + requiredArea > facility.StandardArea)
                    throw new Exception("Not enough space in the production facility.");

                var contract = new EquipmentPlacementContract
                {
                    ProductionFacilityId = facility.Id,
                    ProcessEquipmentTypeId = equipmentType.Id,
                    EquipmentQuantity = request.Quantity
                };

                _context.EquipmentPlacementContracts.Add(contract);
                await _context.SaveChangesAsync();

                Console.WriteLine("Contract created successfully.");
                return new CreateContractResponse(true, new(contract));          
        }
    }
}
