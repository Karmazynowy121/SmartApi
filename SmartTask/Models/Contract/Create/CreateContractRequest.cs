namespace SmartTask.Models.Contract.Create
{
    public class CreateContractRequest
    {
        public int ProductionFacilityId { get; set; }
        public int ProcessEquipmentTypeId { get; set; }
        public int Quantity { get; set; }
    }
}
