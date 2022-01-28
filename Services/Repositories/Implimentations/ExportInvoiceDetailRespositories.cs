using AutoMapper;
using DLL;
using Services.Repositories.Interfaces;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories.Implimentations
{
    public class ExportInvoiceDetailRespositories : IExportInvoiceDetailRepositories
    {
        private readonly DataContext db;
        private readonly IMapper mp;
        public ExportInvoiceDetailRespositories(DataContext dataContext,IMapper mapper)
        {
            db = dataContext;
            mp = mapper;
        }
        public async Task<int> Delete(string Id)
        {
            
        }

        public async Task<List<ExportDetailViewModel>> GetByID()
        {
            throw new NotImplementedException();
        }

        public async Task<int> Insert(ExportDetailViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(ExportDetailViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
