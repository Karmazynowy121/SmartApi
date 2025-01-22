using SmartTask.Models.Contract.Create;
using SmartTask.Models.Contract.Get;

namespace SmartTask.Services
{
    public interface IContractService
    {
        Task<List<ContractResponse>> GetContractsAsync();
        Task<CreateContractResponse> CreateContractAsync(CreateContractRequest request);
    }
}
