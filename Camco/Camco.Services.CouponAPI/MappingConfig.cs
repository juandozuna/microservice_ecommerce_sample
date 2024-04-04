using AutoMapper;
using Camco.Services.CouponAPI.Models;
using Camco.Services.CouponAPI.Models.Dto;

namespace Camco.Services.CouponAPI;

public abstract class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<CouponDto, Coupon>();
            config.CreateMap<Coupon, CouponDto>();
        });
        return mappingConfig;
    }
}