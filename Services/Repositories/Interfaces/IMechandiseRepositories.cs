using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories.Interfaces
{
    public interface IMechandiseRepositories
    {
        Task<int> Insert(MechandiseViewModel model);
        Task<int> Update(MechandiseViewModel model);
        Task<int> Delete(string Id);
        Task<List<MechandiseViewModel>> GetAll();
    }
}
