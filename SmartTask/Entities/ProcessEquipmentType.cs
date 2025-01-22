namespace SmartTask.Entities
{
    public class ProcessEquipmentType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Area { get; set; }
        public ICollection<EquipmentPlacementContract> Contracts { get; set; }
    }
}
