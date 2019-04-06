using System;
using System.Collections.Generic;
using System.Text;
using Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.EntityFramework.Config
{
    internal class ApplicantConfig : IEntityTypeConfiguration<Applicant>
    {
        public ApplicantConfig()
        {
            
        }

        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            // Defining Primary Key -->
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).HasColumnName("ApplicantId");

            // Defining Version as RowVersion -->
            builder.Property(x => x.Version).IsRowVersion();
        }
    }
}
