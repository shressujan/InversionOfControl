using Api.Models;

namespace Service.DataAccess.Models
{
    public class VehicleInfoDto
    {
        public VehicleInfoDto()
        {
            
        }

        public string LisencePlateNumber { get; set; } = null!;

        public VehicleMake VehicleMake { get; set; }

        public VehicleModel VehicleModel { get; set; }

        public Color VehicleColor { get; set; }
    }

}
