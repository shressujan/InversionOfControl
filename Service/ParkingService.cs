using System.Collections.Immutable;
using Api;
using Api.Models;
using AutoMapper;
using Service.DataAccess;
using Service.DataAccess.Models;

namespace Service
{
    public class ParkingService: IParkingApi
    {
        private readonly IParkingRepository _parkingRepository;
        private readonly IMapper _mapper;

        public ParkingService(IParkingRepository parkingRepository, IMapper mapper)
        {
            _parkingRepository = parkingRepository ?? throw new ArgumentNullException(nameof(parkingRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<VehicleParkingInfo> Park(VehicleInfo vehicle)
        {
            var vehicleParkingInfo = new VehicleParkingInfo(vehicle, DateTime.UtcNow);

            var vehicleParkingInfoDto = _mapper.Map<VehicleParkingInfoDto>(vehicleParkingInfo);

            await _parkingRepository.Park(vehicleParkingInfoDto).ConfigureAwait(false);

            return vehicleParkingInfo;
        }

        public async Task<VehicleParkingInfo> GetParkingInformation(string lisencePlateNumber)
        {
            var vehicleParkingInfoDto = await _parkingRepository.GetVehicleParkingInfo(lisencePlateNumber);

            var vehicleParkingInfo = _mapper.Map<VehicleParkingInfo>(vehicleParkingInfoDto);

            return vehicleParkingInfo;
        }

        public async Task<IReadOnlyList<VehicleParkingInfo>> GetAllParkingInformation()
        {
            var vehicleParkingInfoDtos = await _parkingRepository.GetAllVehiclesInParkingLot();

            var vehicleParkingInfos = _mapper.Map<List<VehicleParkingInfo>>(vehicleParkingInfoDtos);

            return vehicleParkingInfos;
        }
    }
}