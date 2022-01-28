using DLL.Entity;
using DLL.Extention;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace DLL.Configurations
{
    public class UnitConfigurations:DbEntityConfiguration<Unit>
    {
        public override void Configure(EntityTypeBuilder<Unit> entity)
        {
            entity.HasKey(u => new { u.UnitID});
        }
    }
}
