using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories.Interfaces
{
    public interface IExportInvoiceRespositories
    {
        Task<int> Insert(ExportInvoiceViewModel model);
        Task<int> Update(ExportInvoiceViewModel model);
        Task<int> Delete(string Id);
        //Task<List<ExportInvoiceViewModel>> GetByUserID();
    }
}
