
using AutoMapper;
using DLL;
using DLL.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
//using OfficeOpenXml;
//using OfficeOpenXml.Style;
//using Services.Helper;
using Services.Repositories.Interfaces;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Repositories.Implimentations
{
    public class StockRepositories: IStockRepositories
    {
        private readonly DataContext db;
        private readonly IMapper mp;
        public StockRepositories(DataContext datacontext, IMapper mapper)
        {
            this.db = datacontext;
            this.mp = mapper;
        }
        public async Task<int> Delete (string Id)
        {
            var entity = await db.Stocks.FirstOrDefaultAsync(x => x.StockID == Id);
            db.Stocks.Remove(entity);
            var rs = await db.SaveChangesAsync();
            return rs;
            
        }

        public async Task<int> Insert(StockViewModel model)
        {
            model.StockID = Guid.NewGuid().ToString();
            var entity = mp.Map<Stock>(model);
            await db.AddAsync(entity);
            var rs = await db.SaveChangesAsync();
            return rs;
        }
        public async Task<int> Update(StockViewModel model) 
        {
            var v = await db.Stocks.AsNoTracking().FirstOrDefaultAsync(x => x.StockID == model.StockID);
            v.StockName = model.StockName.Trim();
            v.StockAddr = model.StockAddr.Trim();
            v.StockNote = model.StockNote.Trim();
            db.Stocks.Update(v);
            var rs = await db.SaveChangesAsync();
            return rs;
        } 
        

        public async Task<List<StockViewModel>> GetAll()
        {
            var query = from st in db.Stocks
                        select new StockViewModel
                        {
                            StockID = st.StockID,
                            StockName = st.StockName,
                            StockAddr = st.StockAddr,
                            StockNote = st.StockNote
                        };
            return await query.OrderBy(x => x.StockID).ToListAsync();
        }
    }
   
}
