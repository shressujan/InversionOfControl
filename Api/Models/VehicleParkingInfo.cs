namespace Api.Models
{
    public class VehicleParkingInfo
    {
        public VehicleParkingInfo()
        {
            
        }

        public VehicleParkingInfo(VehicleInfo vehicleInfo)
        {
            VehicleInfo = vehicleInfo;
        }

        public VehicleParkingInfo(VehicleInfo vehicleInfo, DateTime entryDateTime)
        {
            VehicleInfo = vehicleInfo;
            EntryDateTime = entryDateTime;
        }

        public VehicleInfo VehicleInfo { get; set; }
        public DateTime EntryDateTime { get; set; }

        public DateTime RefreshDateTime { get; set; }
    }
}
