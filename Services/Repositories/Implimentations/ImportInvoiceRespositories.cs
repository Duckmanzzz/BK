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

namespace Services.Repositories.Implimentations
{
    public class ImportInvoiceRespositories:IImportIvoiceRepositories
    {
        private readonly DataContext db;
        private readonly IMapper mp;
        public ImportInvoiceRespositories(DataContext datacontext,IMapper mapper)
        {
            db = datacontext;
            mp = mapper;
        }
        public async Task<int> Insert(ImportInvoiceViewModel model)
        {
            model.ImportInvoiceID = Guid.NewGuid().ToString();
            var entity = mp.Map<ImportInvoice>(model);
            await db.AddAsync(entity);
            var rs = await db.SaveChangesAsync();
            return rs;
        }
        public async Task<int> Update(ImportInvoiceViewModel model)
        {
            var i = await db.ImportInvoices.AsNoTracking().FirstOrDefaultAsync(x => x.ImportInvoiceID == model.ImportInvoiceID);
            i.UserId = model.UserId;
            i.StockId = model.StockId;
            i.ImportTotalCash = model.ImportTotalCash;

            db.ImportInvoices.Update(i);
            //foreach(var item in model.ListImportDetail) {

            //}
            //Fix Me 
            var rs = await db.SaveChangesAsync();
            return rs;

        }
        public async Task<int> Delete(string Id)
        {
            var entity = await db.ImportInvoices.FirstOrDefaultAsync(x => x.ImportInvoiceID == Id);
            db.ImportInvoices.Remove(entity);
            var rs = await db.SaveChangesAsync();
            return rs;
        }
    }
}
