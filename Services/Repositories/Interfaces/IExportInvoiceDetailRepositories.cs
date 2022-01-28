using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories.Interfaces
{
    public interface IExportInvoiceDetailRepositories
    {
        Task<int> Insert(ExportDetailViewModel model);
        Task<int> Update(ExportDetailViewModel model);
        Task<int> Delete(string Id);
        //Task<List<ExportDetailViewModel>> GetByID();
        //Task<List<ExportDetailViewModel>> GetByExportEnvoiceID();
    }
}
