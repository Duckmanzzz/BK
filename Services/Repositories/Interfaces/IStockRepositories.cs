using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories.Interfaces
{
    public interface IStockRepositories
    {
        Task<int> Insert(StockViewModel model);
        Task<int> Update(StockViewModel model);
        Task<int> Delete(string Id);
        Task<List<StockViewModel>> GetAll();
        
    }
}
