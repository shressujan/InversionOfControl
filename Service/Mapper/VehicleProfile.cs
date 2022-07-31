using System.Collections.Immutable;
using Api.Models;
using AutoMapper;
using Service.DataAccess.Models;

namespace Service.Mapper
{
    public class VehicleProfile: Profile
    {

        public VehicleProfile()
        {

            CreateMap<VehicleParkingInfo, VehicleParkingInfoDto>()
                .ForMember(dest => dest.VehicleInfoDto,
                    opt => opt.MapFrom(src => src.VehicleInfo))
                .ReverseMap();

            CreateMap<VehicleInfo, VehicleInfoDto>().ReverseMap();
        }
     
    }
}
