using Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.EntityFramework.Config
{
    internal class AdministratorConfig : IEntityTypeConfiguration<Administrator>
    {
        public AdministratorConfig()
        {
            
        }

        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            // Defining Primary Key -->
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).HasColumnName("AdministratorId");

            // Defining Version as RowVersion -->
            builder.Property(x => x.Version).IsRowVersion();
        }
    }
}
