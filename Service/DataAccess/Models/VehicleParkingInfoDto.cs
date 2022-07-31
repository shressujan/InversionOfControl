namespace Service.DataAccess.Models
{
    public class VehicleParkingInfoDto
    {
        public VehicleParkingInfoDto()
        {
            
        }

        public VehicleParkingInfoDto(VehicleInfoDto vehicleInfoDto)
        {
            VehicleInfoDto = vehicleInfoDto;
        }

        public VehicleInfoDto VehicleInfoDto { get; set; }
        public DateTime EntryDateTime { get; set; }
    }
}
