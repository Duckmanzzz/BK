using DLL.Entity;
using DLL.Extention;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Configurations
{
    public class ExportInvoiceDetailConfigurations:DbEntityConfiguration<ExportInvoiceDetail>
    {
        public override void Configure(EntityTypeBuilder<ExportInvoiceDetail> entity)
        {
            entity.HasKey(c => new { c.ExportInvoiceDetailID });
            entity.HasOne<Stock>(u => u.LinkStockID)
                .WithMany(s => s.ListExportInvoice)
                .HasForeignKey(fc => fc.StockId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne<Mechandise>(c => c.LinkMechandiseID)
                .WithMany(f => f.LinkExportInvoiceDetail)
                .HasForeignKey(fc => fc.MechandiseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
