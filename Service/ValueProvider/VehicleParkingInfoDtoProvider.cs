using System.Diagnostics;
using Microsoft.Extensions.Hosting;
using Service.DataAccess;
using Service.DataAccess.Models;

namespace Service.ValueProvider
{
    public class VehicleParkingInfoDtoProvider : IHostedService, IValueProvider<IReadOnlyList<VehicleParkingInfoDto>>
    {
        private readonly IParkingRepository _parkingRepository;

        private IReadOnlyList<VehicleParkingInfoDto>? _vehicleParkingInfoDtos;

        public VehicleParkingInfoDtoProvider(IParkingRepository parkingRepository)
        {
            _parkingRepository = parkingRepository ?? throw new ArgumentNullException(nameof(parkingRepository));
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var time = Stopwatch.StartNew();
            _vehicleParkingInfoDtos = _parkingRepository.GetAllVehiclesInParkingLot();
            time.Stop();

            Console.WriteLine("Completed in : " + time.Elapsed);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<VehicleParkingInfoDto>? GetValue()
        {
            return _vehicleParkingInfoDtos;
        }
    }
}
