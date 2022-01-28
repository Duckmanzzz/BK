using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories.Interfaces
{
    public interface IImportIvoiceDetailRepositories
    {
        Task<int> Insert(ImportDetailViewModel model);
        Task<int> Update(ImportDetailViewModel model);
        Task<int> Delete(string Id);
    }
}
