using System.Reflection;
using Api;
using Data;
using Quartz;
using Service;
using Service.DataAccess;
using Service.DataAccess.Models;
using Service.Mapper;
using Service.Scheduler.Job;
using Service.ValueProvider;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add repositories
builder.Services.AddSingleton<IParkingRepository, MongoParkingRepository>();

//Add value providers
builder.Services.AddSingleton(sp => 
    new VehicleParkingInfoDtoProvider(
        sp.GetRequiredService<IParkingRepository>()
        ));
builder.Services.AddHostedService(sp => sp.GetRequiredService<VehicleParkingInfoDtoProvider>());
builder.Services.AddSingleton<IValueProvider<IReadOnlyList<VehicleParkingInfoDto>>>(sp => sp.GetRequiredService<VehicleParkingInfoDtoProvider>());
builder.Services.AddSingleton<IValueProviderForceUpdate<IReadOnlyList<VehicleParkingInfoDto>>>(sp => sp.GetRequiredService<VehicleParkingInfoDtoProvider>());
builder.Services.AddSingleton<IParkingApi, ParkingService>();

// builder.Services.AddHostedService<VehicleParkingInfoDtoProvider>();
// builder.Services.AddSingleton<IValueProvider<VehicleParkingInfoDtos>, VehicleParkingInfoDtoProvider>();
// builder.Services.AddSingleton<IParkingApi, ParkingService>();

//Add quartz
builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();
    var jobKey = new JobKey("RefreshJob");
    q.AddJob<RefreshJob>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("RefreshJob-trigger")
        .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(09,51)));
});

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

static Assembly[] GetAutoMapperAssembliesToScan()
    => new[]
    {
        typeof(VehicleProfile).Assembly,
        typeof(Program).Assembly
    }.Distinct().ToArray();

builder.Services.AddAutoMapper(GetAutoMapperAssembliesToScan());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
