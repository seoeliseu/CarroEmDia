namespace CarroEmDia.Domain.Entities
{
    public class MaintenanceEntity(int vehicleId, int maintenanceTypeId, string description, DateTime maintenanceDate, int mileageAtMaintenance, decimal cost) : BaseEntity, IAggregateRoot
    {
        public int VehicleId { get; private set; } = vehicleId;
        public int MaintenanceTypeId { get; private set; } = maintenanceTypeId;
        public string Description { get; private set; } = description;
        public DateTime MaintenanceDate { get; private set; } = maintenanceDate;
        public int MileageAtMaintenance { get; private set; } = mileageAtMaintenance;
        public decimal Cost { get; private set; } = cost;
        public int? NextExpectedMaintenanceMileage { get; private set; } = null;
        public DateTime? NextExpectedMaintenanceDate { get; private set; } = null;
        public bool IsCompleted { get; private set; } = true;
        public DateTime? RememberAt { get; set; } = null;

        public VehicleEntity? Vehicle { get; private set; }
        public MaintenanceTypeEntity? MaintenanceType { get; private set; }

        public void MarkAsPlanned(DateTime? expectedDate, int? expectedMileage, DateTime? rememberAt)
        {
            IsCompleted = false;
            NextExpectedMaintenanceDate = expectedDate;
            NextExpectedMaintenanceMileage = expectedMileage;
            RememberAt = rememberAt;
        }
    }
}
