﻿using System.Collections.Immutable;
using Api.Models;

namespace Api
{
    public interface IParkingApi
    {
        Task<VehicleParkingInfo> Park(VehicleInfo vehicle);
        Task<VehicleParkingInfo> GetParkingInformation(string lisencePlateNumber);
        IReadOnlyList<VehicleParkingInfo> GetAllParkingInformation();
    }
}