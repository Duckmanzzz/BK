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
    public class ExportInvoiceRespositories:IExportInvoiceRespositories
    {
        DataContext  db;
        IMapper mp;
        public ExportInvoiceRespositories(DataContext datacontext,IMapper mapper)
        {
            db = datacontext;
            mp = mapper;
        }
        public async Task<int> Insert(ExportInvoiceViewModel model)
        {
            model.ExportInvoiceID = Guid.NewGuid().ToString();
            var entity = mp.Map<ExportInvoice>(model);
            await db.AddAsync(entity);
            var rs = await db.SaveChangesAsync();
            return rs;
        }
        public async Task<int> Update(ExportInvoiceViewModel model)
        {
            var e = await db.ExportInvoices.AsNoTracking().FirstOrDefaultAsync(x => x.ExportInvoiceID == model.ExportInvoiceID);
            e.ExportInvoiceUser = model.ExportInvoiceUser.Trim();
            e.ExportTotalCash = model.ExportTotalCash;
            db.ExportInvoices.Update(e);
            var rs = await db.SaveChangesAsync();
            return rs;
        }
        public async Task<int> Delete(string Id)
        {
            var entity = await db.ExportInvoices.FirstOrDefaultAsync(x => x.ExportInvoiceID == Id);
            db.ExportInvoices.Remove(entity);
            var rs = await db.SaveChangesAsync();
            return rs;
        }
    }
}
