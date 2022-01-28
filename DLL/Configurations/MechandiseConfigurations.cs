using DLL.Entity;
using DLL.Extention;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace DLL.Configurations
{
    public class MechandiseConfigurations:DbEntityConfiguration<Mechandise>
    {
        public override void Configure(EntityTypeBuilder<Mechandise> entity)
        {
            entity.HasKey(m => new { m.MechandiseID });
            entity.HasOne<Unit>(u => u.LinkUnit)
                .WithMany(s => s.ListMechandiseID)
                .HasForeignKey(fk => fk.UnitId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
