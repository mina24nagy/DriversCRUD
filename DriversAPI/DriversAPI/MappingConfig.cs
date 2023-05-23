using AutoMapper;

namespace DriversAPI.Models.DTOs
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Driver, DriverDto>();
                config.CreateMap<DriverDto, Driver>();
            });

            return mapperConfig;
        } 
    }
}
