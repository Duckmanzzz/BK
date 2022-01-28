using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories.Interfaces
{
    public interface IUnitRepositories
    {
        Task<int> Insert(UnitViewModel model);
        Task<int> Update(UnitViewModel model);
        Task<int> Delete(string Id);
        Task<List<UnitViewModel>> GetAll();
    }
}
