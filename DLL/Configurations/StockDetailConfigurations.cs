using DLL.Entity;
using DLL.Extention;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Configurations
{
    public class StockDetailConfigurations:DbEntityConfiguration<StockDetail>
    {
        public override void Configure(EntityTypeBuilder<StockDetail> entity)
        {
            entity.HasKey(sk => new { sk.StockDetailID });
            entity.HasOne<Mechandise>(s => s.LinkMechandiseID)
                .WithMany(c => c.ListStockDetail)
                .HasForeignKey(fc => fc.MechandiseId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne<Stock>(s => s.LinkStockID)
                .WithMany(c => c.ListStockDetail)
                .HasForeignKey(fc => fc.StockId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
