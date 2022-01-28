using DLL.Entity;
using DLL.Extention;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Configurations
{
    internal class ExportInvoiceConfigurations:DbEntityConfiguration<ExportInvoice>
    {
        public override void Configure(EntityTypeBuilder<ExportInvoice> entity)
        {
            entity.HasKey(k => new { k.ExportInvoiceID });
            entity.HasOne<User>(u => u.LinkUserID)
                .WithMany(c => c.ExportInvoices)
                .HasForeignKey(fc => fc.ExportInvoiceUser)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
