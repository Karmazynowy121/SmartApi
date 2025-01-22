using Microsoft.AspNetCore.Mvc;
using Moq;
using SmartTask.Controllers;
using SmartTask.Entities;
using SmartTask.Models.Contract.Create;
using SmartTask.Models.Contract.Get;
using SmartTask.Queue;
using SmartTask.Services;
using System.Diagnostics.Contracts;

namespace SmartTaskTests
{
    public class ContractControllerTests
    {
        private readonly Mock<IContractService> _mockService;
        private readonly ContractsController _controller;
        private readonly IBackgroundTaskQueue _taskQueue;

        public ContractControllerTests()
        {
            _mockService = new Mock<IContractService>();
            _taskQueue = new BackgroundTaskQueue();
            _controller = new ContractsController(_mockService.Object, _taskQueue);
        }

        [Fact]
        public async Task GetContracts_ReturnsOkResult_WithListOfContracts()
        {
            // Arrange
            var mockContracts = new List<ContractResponse>
        {
            new ContractResponse { ProductionFacilityName = "Facility A", ProcessEquipmentTypeName = "Type A", Quantity = 10 },
            new ContractResponse { ProductionFacilityName = "Facility B", ProcessEquipmentTypeName = "Type B", Quantity = 5 }
        };

            _mockService.Setup(service => service.GetContractsAsync())
                .ReturnsAsync(mockContracts);

            // Act
            var result = await _controller.GetContracts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedContracts = Assert.IsAssignableFrom<List<ContractResponse>>(okResult.Value);
            Assert.Equal(2, returnedContracts.Count);
        }

        [Fact]
        public async Task CreateContract_ReturnsOkResult_WhenContractIsCreated()
        {
            // Arrange
            var mockRequest = new CreateContractRequest
            {
                ProductionFacilityId = 1,
                ProcessEquipmentTypeId = 2,
                Quantity = 5
            };

            var mockContract = new EquipmentPlacementContract
            {
                Id = 1,
                ProductionFacilityId = mockRequest.ProductionFacilityId,
                ProcessEquipmentTypeId = mockRequest.ProcessEquipmentTypeId,
                EquipmentQuantity = mockRequest.Quantity
            };

            var mockResponse = new CreateContractResponse(true, new ContractDTO(mockContract));

            _mockService.Setup(service => service.CreateContractAsync(It.IsAny<CreateContractRequest>()))
                .ReturnsAsync(mockResponse);

            // Act
            var result = await _controller.CreateContract(mockRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedResponse = Assert.IsType<CreateContractResponse>(okResult.Value);

            // Sprawdzanie poprawnoœci zwracanych danych
            Assert.True(returnedResponse.IsSuccessed);
            Assert.Equal(mockContract.Id, returnedResponse.Contract.ContractId);
            Assert.Equal(mockRequest.ProductionFacilityId, returnedResponse.Contract.ProductionFacilityId);
            Assert.Equal(mockRequest.ProcessEquipmentTypeId, returnedResponse.Contract.ProcessEquipmentTypeId);
            Assert.Equal(mockRequest.Quantity, returnedResponse.Contract.Quantity);
        }

    }

}