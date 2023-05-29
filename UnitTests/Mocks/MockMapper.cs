using Nexus;
using AutoMapper;

namespace UnitTests.Mocks
{
    internal class MockMapper
    {
        public static IMapper GetMapper()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingConfig());
            });
            IMapper mapper = mappingConfig.CreateMapper();

            return mapper;
        }
    }
}

