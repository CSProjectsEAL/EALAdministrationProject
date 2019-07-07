using Microsoft.EntityFrameworkCore;
using System;
using Domain.Concrete;
using Repository.EntityFramework.Config;

namespace Repository.EntityFramework
{
    public class EntityRepository : DbContext
    {
        private readonly DbContextOptions<EntityRepository> options;
        private readonly bool useLazyLoading;
        public EntityRepository(DbContextOptions<EntityRepository> options) : base(options)
        {
            this.options = options;
            useLazyLoading = true;

            //Database.Migrate();
        }

        // Underneath create as many DbSet' as you have domain classes you wish to persist.
        // Each DbSet should have a Config file aplied in the method 'OnModelCreating'

        // e.g
        // public virtual DbSet<YourDomainClass> YourDomainClassInPlural { get; set; }
        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<AvailableTime> AvailableTimes { get; set; }
        public virtual DbSet<Interview> Interviews { get; set; }
        public virtual DbSet<Interviewer> Interviewers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // To Lazy Load properties they require the keywork Virtual.
            // Making use of Lazy load means that the property only loads as it is about to be used,
            // which improves performance of the program
            optionsBuilder.UseLazyLoadingProxies(useLazyLoading);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Create a new class under Config, with the name of the domain class you wish to persist,
            // ending it in Config, to differnetiate it from the actual class

            // e.g
            // modelBuilder.ApplyConfiguration(new YourDomainClassConfig());

            modelBuilder.ApplyConfiguration(new AdministratorConfig());
            modelBuilder.ApplyConfiguration(new ApplicantConfig());
            modelBuilder.ApplyConfiguration(new AppointmentConfig());
            modelBuilder.ApplyConfiguration(new AvailableTimeConfig());
            modelBuilder.ApplyConfiguration(new InterviewConfig());
            modelBuilder.ApplyConfiguration(new InterviewerConfig());
        }
    }
}
