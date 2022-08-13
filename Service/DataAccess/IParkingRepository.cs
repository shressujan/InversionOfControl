using Service.DataAccess.Models;

namespace Service.DataAccess
{
    public interface IParkingRepository
    {
        /// <summary>
        /// Get Information of all vehicles currently parked in the parking lot.
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<VehicleParkingInfoDto> GetAllVehiclesInParkingLot();

        /// <summary>
        /// Save the entry date time and vehicle information when a vehicle enters parking lot.
        /// </summary>
        /// <param name="parkedVehicle"></param>
        Task Park(VehicleParkingInfoDto parkedVehicle);

        /// <summary>
        /// Retrieve parking information of vehicle for requested lisence plate number.
        /// </summary>
        /// <param name="lisencePlateNumber"></param>
        /// <returns></returns>
        Task<VehicleParkingInfoDto> GetVehicleParkingInfo(string lisencePlateNumber);
    }
}
