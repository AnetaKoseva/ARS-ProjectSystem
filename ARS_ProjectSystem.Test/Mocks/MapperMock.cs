namespace ARS_ProjectSystem.Test.Mocks
{
    using ARS_ProjectSystem.Infrastructure;
    using AutoMapper;
    using System;

    public static class MapperMock
    {
        public static IMapper Instance
        {
            get
            {
                var mapperConfiguration = new MapperConfiguration(config =>
                  {
                      config.AddProfile<MappingProfile>();
  
                  });
                return new Mapper(mapperConfiguration);
            }
        }
    }
}
