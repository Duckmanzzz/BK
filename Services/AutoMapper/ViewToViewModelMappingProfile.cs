using AutoMapper;
using DLL.Entity;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.AutoMapper
{
    public class ViewToViewModelMappingProfile:Profile
    {
        public ViewToViewModelMappingProfile()
        {
            CreateMap<Stock,StockViewModel > ();
        }
    }
}
