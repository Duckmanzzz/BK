using AutoMapper;
using DLL;
using DLL.Entity;
using Microsoft.EntityFrameworkCore;
using Services.Helper;
using Services.Repositories.Interfaces;
using Services.ViewModels;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories.Implimentations
{
    public class UserRespositories:IUserRespositories
    {
        private readonly DataContext db;
        private readonly IMapper mp;
        public UserRespositories(DataContext datacontext,IMapper mapper)
        {
           db = datacontext;
           mp = mapper;
        }
        public async Task<int> Insert(UserViewModel model)
        {
            model.UserID = Guid.NewGuid().ToString();
            var entity = mp.Map<User>(model);
            await db.AddAsync(entity);
            var rs = await db.SaveChangesAsync();
            return rs;
        }
        public async Task<int> Delete(string Id)
        {
            var entity = await db.Users.FirstOrDefaultAsync(x => x.UserID == Id);
            db.Users.Remove(entity);
            var rs = await db.SaveChangesAsync();
            return rs;
        }
        public async Task<int> Update(UserViewModel model)
        {
            var v = await db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserID == model.UserID);
            v.UserFullname = model.UserFullname;
            v.UserPassword = model.UserPassword;
            v.UserAddr = model.UserAddr;
            v.UserTel = model.UserTel;
            db.Users.Update(v);
            var rs = await db.SaveChangesAsync();
            return rs;
        }
        public async Task<UserViewModel> GetById(string Id)
        {
            var query = from us in db.Users
                        where us.UserID == Id
                        select new UserViewModel
                        {
                            UserID = us.UserID,
                            UserName = us.UserName ??string.Empty,
                            UserFullname = us.UserFullname,
                            UserAddr = us.UserAddr,
                            UserTel = us.UserTel
                            
                        };
            return await query.FirstOrDefaultAsync();
        }   
        public async Task<UserViewModel> GetByName(string username)
        {
            var query = from u in db.Users
                        where u.UserFullname == username
                        select new UserViewModel
                        {
                            UserID = u.UserID,
                            UserName = u.UserName ?? string.Empty,
                            UserFullname = u.UserFullname,
                            UserAddr = u.UserAddr,
                            UserTel = u.UserTel

                        };
            return await query.FirstOrDefaultAsync();
        }
        public async Task<int> Login(string username, string password)
        {
            var checkusername = await this.CheckUsername(username.Trim());
            if (checkusername == true)
            {
                var checkpassword = await this.CheckPassword(username, password);
                if (checkpassword == true)
                {
                    return 1;// dang nhap thanh cong
                }
                else return 0;//sai mat khau
            }
            else return -1;//tai khoan khong ton tai
        }
        public async Task<bool> CheckPassword(string password,string username)
        {
            var passMD5 = CreateMD5.ConvertoMD5(password.Trim());
            var entity = await db.Users.FirstOrDefaultAsync(x => x.UserName.Trim() == username.Trim());
            if (entity.UserPassword != passMD5) return false;
            else return true;
        }
        public async Task<bool> CheckUsername(string username)
        {
            var rs = await db.Users.FirstOrDefaultAsync(x => x.UserName.Trim() == username.Trim());
            if (rs == null) return false;
            else return true;
        }
    }
}
