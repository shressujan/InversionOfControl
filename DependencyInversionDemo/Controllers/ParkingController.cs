using System.Collections.Immutable;
using Api;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingApi _parkingApi;

        public ParkingController(IParkingApi parkingApi)
        {
            _parkingApi = parkingApi ?? throw new ArgumentNullException(nameof(parkingApi));
        }

        [HttpPost]
        public Task<VehicleParkingInfo> Park(VehicleInfo vehicle)
        {
            return _parkingApi.Park(vehicle);
        }

        [HttpGet("info")]
        public Task<VehicleParkingInfo> GetParkingInformation(string lisencePlateNumber)
        {
            return _parkingApi.GetParkingInformation(lisencePlateNumber);
        }

        [HttpGet("info/all")]
        public Task<IReadOnlyList<VehicleParkingInfo>> GetAllParkingInformation()
        {
            return _parkingApi.GetAllParkingInformation();
        }
    }
}
