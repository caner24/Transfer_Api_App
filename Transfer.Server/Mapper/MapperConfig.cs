using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Server.Mapper
{
    public static class MapperConfig
    {
        public static IMapper ConfigureMappings()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MyMappingProfile>();
            });

            return config.CreateMapper();
        }
    }
}
