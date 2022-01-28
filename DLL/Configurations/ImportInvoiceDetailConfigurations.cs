using DLL.Entity;
using DLL.Extention;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Configurations
{
    public class ImportInvoiceDetailConfigurations:DbEntityConfiguration<ImportInvoiceDetail>
    {
        public override void Configure(EntityTypeBuilder<ImportInvoiceDetail> entity)
        {
            entity.HasKey(kc => new { kc.ImportInvoiceDetailID });
            entity.HasOne<ImportInvoice>(d => d.LinkInvoiceID)
                .WithMany(s => s.LinkImportDetailID)
                .HasForeignKey(fc => fc.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne<Mechandise>(d => d.LinkMechandiseID)
                .WithMany(s => s.LinkImportInvoiceDetail)
                .HasForeignKey(fd =>fd.LinkMechandiseId )
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
