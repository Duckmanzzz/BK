using AutoMapper;
using DLL;
using DLL.Entity;
using Microsoft.EntityFrameworkCore;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Services.Repositories.Interfaces;

namespace Services.Repositories.Implimentations
{
    public class StockDetailRepositories:IStockDetailRepositories
    {
        private readonly DataContext db;
        private readonly IMapper mp;
        public StockDetailRepositories(DataContext datacontext,IMapper mapper)
        {
            db = datacontext;
            mp = mapper;
        }
        public async Task<int> Insert(StockDetailViewModel model)
        {
            model.StockDetailID = Guid.NewGuid().ToString();
            var entity = mp.Map<StockDetail>(model);
            await db.AddAsync(entity);
            var rs = await db.SaveChangesAsync();
            return rs;
        }
        public async Task<int> Update(StockDetailViewModel model)
        {
            var sd = await db.StockDetails.AsNoTracking().FirstOrDefaultAsync(x => x.StockDetailID == model.StockDetailID);
            sd.StockId = model.StockID.Trim();
            sd.MechandiseId = model.MechandiseId.Trim();
            sd.Quantity = model.Quantity;
            db.StockDetails.Update(sd);
            var rs = await db.SaveChangesAsync();
            return rs;
        }
        public async Task<int> Delete(string Id)
        {
            var entity = await db.StockDetails.FirstOrDefaultAsync(x => x.StockDetailID == Id);
            db.StockDetails.Remove(entity);
            var rs = await db.SaveChangesAsync();
            return rs;
        }
        public async Task<List<StockDetailViewModel>> GetAll()
        {
            var query = from sd in db.StockDetails
                        join m in db.Mechandises on sd.MechandiseId equals m.MechandiseID
                        join s in db.Stocks on sd.StockId equals s.StockID
                        join u in db.Units on m.UnitId equals u.UnitID
                        select new StockDetailViewModel
                        {
                            StockDetailID = sd.StockDetailID,
                            StockID = s.StockName,
                            MechandiseId = m.MechandiseName,
                            Quantity = sd.Quantity,
                            MechandiseProduct = m.MechandiseProduct,
                            Unit = u.UnitName
                        };
            return await query.OrderBy(x => x.StockDetailID).ToListAsync();
        }
    }
}
