using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMapping()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ViewModelToViewMappingProfile());
                cfg.AddProfile(new ViewToViewModelMappingProfile());
            });
        }
    }
}
