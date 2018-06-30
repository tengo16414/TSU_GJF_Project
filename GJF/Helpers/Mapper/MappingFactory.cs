using GJF.Core.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GJF.Helpers.Mapper
{
    public class MappingFactory
    {
        public static void Map()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MappingProfile>();

            });

        }
    }
}