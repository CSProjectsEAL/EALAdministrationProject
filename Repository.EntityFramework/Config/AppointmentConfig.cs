using System;
using System.Collections.Generic;
using System.Text;
using Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.EntityFramework.Config
{
    internal class AppointmentConfig : IEntityTypeConfiguration<Appointment>
    {
        public AppointmentConfig()
        {
            
        }

        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            // Defining Primary Key -->
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).HasColumnName("AppointmentId");

            // Defining Version as RowVersion -->
            builder.Property(x => x.Version).IsRowVersion();
        }
    }
}
