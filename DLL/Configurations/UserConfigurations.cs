using DLL.Entity;
using DLL.Extention;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace DLL.Configurations
{
    public class UserConfigurations:DbEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(p => new { p.UserID });
            
        }
    }
}
