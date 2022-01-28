using DLL.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using DLL.Extention;


namespace DLL.Configurations
{
    public class StockConfigurations : DbEntityConfiguration<Stock>
    {
        public override void Configure(EntityTypeBuilder<Stock> entity)
        {
            entity.HasKey(c => new { c.StockID });
            
        }
    }
}
