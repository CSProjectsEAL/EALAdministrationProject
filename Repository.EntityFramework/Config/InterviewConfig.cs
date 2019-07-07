using System;
using System.Collections.Generic;
using System.Text;
using Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.EntityFramework.Config
{
    internal class InterviewConfig : IEntityTypeConfiguration<Interview>
    {
        public InterviewConfig()
        {
            
        }

        public void Configure(EntityTypeBuilder<Interview> builder)
        {
            // Defining Primary Key -->
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).HasColumnName("InterviewId");

            // Defining Version as RowVersion -->
            builder.Property(x => x.Version).IsRowVersion();

            // Defining whether or not a property is required 
            // Takes in a false in the 'IsRequred' if one wish to make it not required
            // Properties that are nullable default to be not required -->

            builder.HasOne(x => (Applicant)x.Applicant).WithOne().HasForeignKey<Interview>(x => x.FK_Applicant).IsRequired();

            builder.HasOne(x => (Interviewer) x.Interviewer).WithMany(x => (ICollection<Interview>) x.Interviews)
                .HasForeignKey(x => x.FK_Interviewer).IsRequired();

            builder.HasOne(x => (Appointment) x.Appointment).WithOne().HasForeignKey<Interview>(x => x.FK_Appointment).IsRequired();
        }
    }
}
