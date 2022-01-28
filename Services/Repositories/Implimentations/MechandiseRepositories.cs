using AutoMapper;
using DLL;
using DLL.Entity;
using Microsoft.EntityFrameworkCore;
using Services.Repositories.Interfaces;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Services.Repositories.Implimentations
{
    public class MechandiseRepositories:IMechandiseRepositories
    {
        private readonly DataContext db;
        private readonly IMapper mp;
        public MechandiseRepositories(DataContext datacontext,IMapper mapper)
        {
            db = datacontext;
            mp = mapper;
        }
        public async Task<int> Insert(MechandiseViewModel model)
        {
            model.MechandiseID = Guid.NewGuid().ToString();
            var entity = mp.Map<Mechandise>(model);
            await db.AddAsync(entity);
            var rs = await db.SaveChangesAsync();
            return rs;
        }
        public async Task<int> Update(MechandiseViewModel model)
        {
            var m = await db.Mechandises.AsNoTracking().FirstOrDefaultAsync(x => x.MechandiseID == model.MechandiseID);
            m.MechandiseName = model.MechandiseName.Trim();
            m.MechandiseProduct = model.MechandiseProduct.Trim();
            m.MechandiseImportPrice = model.MechandiseImportPrice;
            m.MechandiseExportPrice = model.MechandiseExportPrice;
            m.UnitId = model.UnitId.Trim();
            db.Mechandises.Update(m);
            var rs = await db.SaveChangesAsync();
            return rs;
        }
        public async Task<int> Delete(string Id)
        {
            var entity = await db.Mechandises.FirstOrDefaultAsync(x => x.MechandiseID == Id);
            db.Mechandises.Remove(entity);
            var rs = await db.SaveChangesAsync();
            return rs;
        }
        public async Task<List<MechandiseViewModel>> GetAll()
        {
            var query = from mc in db.Mechandises
                        select new MechandiseViewModel
                        {
                            MechandiseID = mc.MechandiseID,
                            MechandiseName = mc.MechandiseName,
                            MechandiseProduct = mc.MechandiseProduct,
                            MechandiseExportPrice = mc.MechandiseExportPrice,
                            MechandiseImportPrice = mc.MechandiseImportPrice
                        };
            return await query.OrderBy(x => x.MechandiseID).ToListAsync();
        }
    }
}
