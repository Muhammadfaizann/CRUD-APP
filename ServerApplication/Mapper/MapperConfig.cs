using AutoMapper;

namespace ServerApplication.Mapper
{
    public class MapperConfig
    {
        public static MapperConfiguration AutoMapperSetup()
        {
            try
            {
                return new MapperConfiguration(Configure);
            }
            catch (System.Exception Exception)
            {
                throw new System.Exception($"Map:- {Exception.ToString()}");
            }
        }

        private static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.AddProfile(new MapperProfile());
        }
    }
}
