using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories.Interfaces
{
    public interface IImportIvoiceRepositories
    {
        Task<int> Insert(ImportInvoiceViewModel model);
        Task<int> Update(ImportInvoiceViewModel model);
        Task<int> Delete(string Id);

    }
}
