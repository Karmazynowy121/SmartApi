using Microsoft.AspNetCore.Mvc;
using SmartTask.Models.Contract.Create;
using SmartTask.Queue;
using SmartTask.Services;

namespace SmartTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractsController : ControllerBase
    {
        private readonly IContractService _contractService;
        private readonly IBackgroundTaskQueue _taskQueue;

        public ContractsController(IContractService contractService, IBackgroundTaskQueue backgroundQueue)
        {
            _contractService = contractService;
            _taskQueue = backgroundQueue;
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateContract([FromBody] CreateContractRequest request)
        //{
        //    try
        //    {
        //        var response = await _contractService.CreateContractAsync(request);
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { Error = ex.Message });
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> CreateContract([FromBody] CreateContractRequest request)
        {
            try
            {
                var response = await _contractService.CreateContractAsync(request);

                _taskQueue.QueueBackgroundWorkItem(async token =>
                {
                    await Task.Delay(200000, token);
                });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetContracts()
        {
            var contracts = await _contractService.GetContractsAsync();
            return Ok(contracts);
        }
    }

}
