using AutoMapper;
using DLL.Entity;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.AutoMapper
{
    public class ViewModelToViewMappingProfile:Profile
    {
        public ViewModelToViewMappingProfile()
        {
            CreateMap<StockViewModel, Stock>();
        }
    }
}
