using System.Diagnostics;
using Microsoft.Extensions.Hosting;
using Service.DataAccess;
using Service.DataAccess.Models;

namespace Service.ValueProvider
{
    public class VehicleParkingInfoDtoProvider : IHostedService, IValueProviderForceUpdate<IReadOnlyList<VehicleParkingInfoDto>>
    {
        private readonly IParkingRepository _parkingRepository;

        private IReadOnlyList<VehicleParkingInfoDto>? _vehicleParkingInfoDtos;

        public VehicleParkingInfoDtoProvider(IParkingRepository parkingRepository)
        {
            _parkingRepository = parkingRepository ?? throw new ArgumentNullException(nameof(parkingRepository));
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var time = Stopwatch.StartNew();
            _vehicleParkingInfoDtos = _parkingRepository.GetAllVehiclesInParkingLot();
            time.Stop();

            Console.WriteLine("Started in : " + time.Elapsed);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<VehicleParkingInfoDto>? GetValue()
        {
            return _vehicleParkingInfoDtos;
        }

        public Task UpdateValue()
        {
            var time = Stopwatch.StartNew();
            _vehicleParkingInfoDtos = _parkingRepository.GetAllVehiclesInParkingLot();
            time.Stop();

            Console.WriteLine("Updated in : " + time.Elapsed);
            return Task.CompletedTask;
        }
    }
}
