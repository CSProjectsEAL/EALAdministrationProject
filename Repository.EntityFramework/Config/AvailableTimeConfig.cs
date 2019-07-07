using System;
using System.Collections.Generic;
using System.Text;
using Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.EntityFramework.Config
{
    internal class AvailableTimeConfig : IEntityTypeConfiguration<AvailableTime>
    {
        public AvailableTimeConfig()
        {
            
        }

        public void Configure(EntityTypeBuilder<AvailableTime> builder)
        {
            // Defining Primary Key -->
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).HasColumnName("AvailableTimeId");

            // Defining Version as RowVersion -->
            builder.Property(x => x.Version).IsRowVersion();

            // Defining whether or not a property is required 
            // Takes in a false in the 'IsRequred' if one wish to make it not required
            // Properties that are nullable default to be not required -->

            builder.HasMany(x => (ICollection<Appointment>) x.Appointments).WithOne().IsRequired();
        }
    }
}
