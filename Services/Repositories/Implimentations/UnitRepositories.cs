using AutoMapper;
using DLL;
using Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Services.ViewModels;
using DLL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Services.Repositories.Implimentations
{
    public class UnitRepositories:IUnitRepositories
    {
        private readonly DataContext db;
        private readonly IMapper mp;
        public UnitRepositories(DataContext datacontext, IMapper mapper)
        {
           db = datacontext;
           mp = mapper;
        }
        public async Task<int> Insert(UnitViewModel model)
        {
            model.UnitID = Guid.NewGuid().ToString();
            var entity = mp.Map<Unit>(model);
            await db.AddAsync(entity);
            var rs = await db.SaveChangesAsync();
            return rs;
        }
        public async Task<int> Update(UnitViewModel model)
        {
            var v = await db.Units.AsNoTracking().FirstOrDefaultAsync(x => x.UnitID == model.UnitID);
            v.UnitName = model.UnitName;
            v.UnitDescreption = model.UnitDescreption;
            db.Units.Update(v);
            var rs = await db.SaveChangesAsync();
            return rs;

        }
        public async Task<int> Delete(string Id)
        {
            var entity = await db.Units.FirstOrDefaultAsync(x => x.UnitID == Id);
            db.Units.Remove(entity);
            var rs = await db.SaveChangesAsync();
            return rs;
        }
        public async Task<List<UnitViewModel>> GetAll()
        {
            var query = from un in db.Units
                        select new UnitViewModel
                        {
                            UnitID = un.UnitID,
                            UnitName = un.UnitName,
                            UnitDescreption = un.UnitDescreption
                        };
            return await query.OrderBy(x => x.UnitID).ToListAsync();
        }
    }
}
