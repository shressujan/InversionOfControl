using Quartz;
using Service.DataAccess.Models;
using Service.ValueProvider;

namespace Service.Scheduler.Job
{
    public class RefreshJob : IJob
    {
        private readonly IValueProviderForceUpdate<IReadOnlyList<VehicleParkingInfoDto>> _valueProvider;

        public RefreshJob(IValueProviderForceUpdate<IReadOnlyList<VehicleParkingInfoDto>> valueProvider)
        {
            _valueProvider = valueProvider ?? throw new ArgumentNullException(nameof(valueProvider));
        }

        public Task Execute(IJobExecutionContext context)
        {
            return _valueProvider.UpdateValue();
        }
    }
}
