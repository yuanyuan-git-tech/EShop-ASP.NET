using ApplicationCore.Entities;
using ApplicationCore.Models;
using AutoMapper;

namespace Infra.Common;

public static class MapperConfig
{
    public static Mapper InitializeAutomapper()
    {
        // Provide all the Mapping Configuration
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Shipper, ShipperRequestModel>();

            
            // Reverse Mapping
            cfg.CreateMap<ShipperRequestModel, Shipper>();
        });

        var mapper = new Mapper(config);
        return mapper;
    }
}