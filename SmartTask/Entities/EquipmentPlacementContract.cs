namespace SmartTask.Entities

{
    public class EquipmentPlacementContract
    {
        public int Id { get; set; }
        public int ProductionFacilityId { get; set; }
        public ProductionFacility ProductionFacility { get; set; }
        public int ProcessEquipmentTypeId { get; set; }
        public ProcessEquipmentType ProcessEquipmentType { get; set; }
        public int EquipmentQuantity { get; set; }
    }
}
