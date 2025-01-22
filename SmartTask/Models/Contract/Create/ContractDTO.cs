using SmartTask.Entities;

namespace SmartTask.Models.Contract.Create
{
    public class ContractDTO
    {
        public int ContractId { get; set; }
        public int ProductionFacilityId { get; set; }
        public int ProcessEquipmentTypeId { get; set; }
        public int Quantity { get; set; }


        public ContractDTO(EquipmentPlacementContract contract)
        {
            ContractId = contract.Id;
            ProductionFacilityId = contract.ProductionFacilityId;
            ProcessEquipmentTypeId = contract.ProcessEquipmentTypeId;
            Quantity = contract.EquipmentQuantity;
        }
    }
}
