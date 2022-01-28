using DLL.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using DLL.Extention;
using Microsoft.EntityFrameworkCore;

namespace DLL.Configurations
{
    public class ImportInvoiceConfigurations:DbEntityConfiguration<ImportInvoice>
    {
        public override void Configure(EntityTypeBuilder<ImportInvoice> entity)
        {
            entity.HasKey(i => new { i.ImportInvoiceID });
            entity.HasOne<User>(u => u.ImportInvoiceUser)
              .WithMany(s => s.ImportInvoices)
              .HasForeignKey(sc => sc.UserId)
              .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne<Stock>(t => t.LinkStockID)
                .WithMany(d => d.ListImportInvoice)
                .HasForeignKey(dc => dc.StockId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
