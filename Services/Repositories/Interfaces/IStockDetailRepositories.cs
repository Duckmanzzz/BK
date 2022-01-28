using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories.Interfaces
{
    public interface IStockDetailRepositories
    {
        Task<int> Insert(StockDetailViewModel model);
        Task<int> Delete(string ID);
        Task<int> Update(StockDetailViewModel model);
        Task<List<StockDetailViewModel>> GetAll();
        //Task<List<StockDetailViewModel>> GetByID();
        //Task<List<StockDetailViewModel>> GetByName();
    }
}
