using System.Collections.Immutable;
using Service.DataAccess;
using Service.DataAccess.Models;

namespace Data
{
    public class MongoParkingRepository: IParkingRepository
    {
        private readonly IDictionary<string, VehicleParkingInfoDto> _parkedVehiclesInfo = new Dictionary<string, VehicleParkingInfoDto>(StringComparer.OrdinalIgnoreCase);
        public Task<List<VehicleParkingInfoDto>> GetAllVehiclesInParkingLot()
        {
            return Task.FromResult(_parkedVehiclesInfo.Values.ToList());
        }

        public Task Park(VehicleParkingInfoDto parkedVehicle)
        {
            if (parkedVehicle == null)
                throw new ArgumentNullException(nameof(parkedVehicle) + " cannot be null.");

            if (string.IsNullOrWhiteSpace(parkedVehicle.VehicleInfoDto.LisencePlateNumber))
                throw new ArgumentException(nameof(parkedVehicle.VehicleInfoDto.LisencePlateNumber) + " cannot be null or empty.");

            var success = _parkedVehiclesInfo.TryAdd(parkedVehicle.VehicleInfoDto.LisencePlateNumber, parkedVehicle);

            if (success)
                return Task.CompletedTask;

            // log failure and return completed task
            return Task.CompletedTask;
        }

        public Task<VehicleParkingInfoDto> GetVehicleParkingInfo(string lisencePlateNumber)
        {
            if (_parkedVehiclesInfo.TryGetValue(lisencePlateNumber, out var vehicleParkingInfoDto))
            {
                return Task.FromResult(vehicleParkingInfoDto);
            }

            return null;
        }
    }
}