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
    public class ImportInvoiceDetailRespositories:IImportIvoiceDetailRepositories
    {
        private readonly DataContext db;
        private readonly IMapper mp;
        public ImportInvoiceDetailRespositories(DataContext datacontext, IMapper mapper)
        {
            db = datacontext;
            mp = mapper;
        }
        public async Task<int> Insert(ImportDetailViewModel model)
        {
            model.ImportInvoiceDetailID = Guid.NewGuid().ToString();
            var entity = mp.Map<ImportInvoice>(model);
            await db.AddAsync(entity);
            var rs =await db.SaveChangesAsync();
            return rs;
        }
        public async Task<int> Update(ImportDetailViewModel model)
        {
            var i = await db.ImportInvoiceDetails.AsNoTracking().FirstOrDefaultAsync(x => x.ImportInvoiceDetailID == model.ImportInvoiceDetailID);
            i.LinkMechandiseId = model.LinkMechandiseId;
            i.InvoiceId = model.InvoiceId;
            i.Quantity = model.Quantity;
            i.ImportCashDetail = model.ImportCashDetail;
            db.ImportInvoiceDetails.Update(i);
            var rs = await db.SaveChangesAsync();
            return rs;
        }
        public async Task<int> Delete(string Id)
        {
            var entity = await db.ImportInvoiceDetails.FirstOrDefaultAsync(x => x.ImportInvoiceDetailID == Id);
            db.ImportInvoiceDetails.Remove(entity);
            var rs = await db.SaveChangesAsync();
            return rs;
        }
    }
}
