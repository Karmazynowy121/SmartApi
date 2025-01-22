namespace SmartTask.Entities

{
    public class ProductionFacility
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int StandardArea { get; set; }
        public ICollection<EquipmentPlacementContract> Contracts { get; set; }
    }
}