using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories.Interfaces
{
    public interface IUserRespositories
    {
        Task<int> Insert(UserViewModel model);
        Task<int> Update(UserViewModel model);
        Task<int> Delete(string Id);
        Task<UserViewModel> GetByName(string username);
        Task<UserViewModel> GetById(string Id);
        Task<int> Login(string username, string password);
        Task<bool> CheckUsername(string username);
        Task<bool> CheckPassword(string password,string username);
    }
}
