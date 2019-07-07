using System;
using System.Collections.Generic;
using System.Text;
using Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.EntityFramework.Config
{
    internal class InterviewerConfig : IEntityTypeConfiguration<Interviewer>
    {
        public InterviewerConfig()
        {

        }

        public void Configure(EntityTypeBuilder<Interviewer> builder)
        {
            // Defining Primary Key -->
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).HasColumnName("InterviewerId");

            // Defining Version as RowVersion -->
            builder.Property(x => x.Version).IsRowVersion();

            builder.HasMany(x => (ICollection<Applicant>) x.ApplicantsToInterview).WithOne();

            builder.HasMany(x => (ICollection<AvailableTime>) x.AvailableTimes).WithOne();
        }
    }
}
