using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Core.Internal;
using Domain.Concrete;
using Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repository.Core;

namespace Repository.EntityFramework
{
    /// <summary>  
    ///  This class should be accessed via the Generic or Serializable classes that inherit from it.  
    /// </summary>   
    public abstract class BaseEntityRepositoryHandler : IBaseRepository
    {
        internal EntityRepository repo = null;
        private bool _useLazyLoading = false;
        public BaseEntityRepositoryHandler(EntityRepository repo)
        {
            this.repo = repo;
        }

        public void ResetRepo()
        {
            throw new NotImplementedException();

            //repo.Dispose();
            //repo = null;

            //repo = new EntityRepository(_useLazyLoading);
        }

        public void Save()
        {
            repo.SaveChanges();
        }

        #region Help Methods
        internal EntityState CheckEntryState(EntityState state, EntityEntry entry)
        {
            if (entry != null)
                state = entry.State;
            return state;
        }

        internal bool VerifyEntryState(EntityState actualState, EntityState desiredState)
        {
            return actualState == desiredState ? true : false;
        }

        internal string GetAmountAdded(ICollection<bool> results)
        {
            return string.Format("Added {0} out of {1}.", results.Where(b => b).Count(), results.Count);
        }
        #endregion

        #region Find Query Builders

        // There should be one query for each case in either 'Find' or 'FindMultiple',
        // meaning if there is a case to find YourDomainClass in both methods,
        // then there should be one query builder, meant to build queries for YourDomainClass
        // as both find methods make use of the same query, only the amount of elements returned are different.
        /*
        private IQueryable<YourDomainClass> BuildFindYourDomainClassQuery(IYourDomainClass y, IQueryable<YourDomainClass> query)
        {
            Check whether or not a property has been set, if it has been set, add a where to the query including the property.

            // e.g
            if (y.PropertyA != default(PropertyAType))
                query = query.Where(x => x.PropertyA == y.PropertyA);

            // If it is a string then use the method 'IsNullOrEmpty' and the method 'Contains'

            if (!y.PropertyB.IsNullOrEmpty())
                query = query.Where(x => x.PropertyB.Contains(y.PropertyB));
            return query;
        }
        */

        private IQueryable<Administrator> BuildFindAdministratorQuery(IAdministrator a, IQueryable<Administrator> query)
        {
            if (!a.Email.IsNullOrEmpty())
                query = query.Where(x => x.Email.Contains(a.Email));
            if (!a.Name.IsNullOrEmpty())
                query = query.Where(x => x.Name.Contains(a.Name));
            return query;
        }
        private IQueryable<Interviewer> BuildFindInterviewerQuery(IInterviewer i, IQueryable<Interviewer> query)
        {
            if (!i.Email.IsNullOrEmpty())
                query = query.Where(x => x.Email.Contains(i.Email));
            if (!i.Name.IsNullOrEmpty())
                query = query.Where(x => x.Name.Contains(i.Name));
            if (!i.Department.IsNullOrEmpty())
                query = query.Where(x => x.Department.Contains(i.Department));
            return query;
        }
        private IQueryable<Interview> BuildFindInterviewQuery(IInterview i, IQueryable<Interview> query)
        {
            if (i.Interviewer != null)
            {
                if (!i.Interviewer.Email.IsNullOrEmpty())
                    query = query.Where(x => x.Interviewer.Email.Contains(i.Interviewer.Email));
                if (!i.Interviewer.Name.IsNullOrEmpty())
                    query = query.Where(x => x.Interviewer.Name.Contains(i.Interviewer.Name));
                if (!i.Interviewer.Department.IsNullOrEmpty())
                    query = query.Where(x => x.Interviewer.Department.Contains(i.Interviewer.Department));
            }

            if (i.Applicant != null)
            {
                if (!i.Applicant.Email.IsNullOrEmpty())
                    query = query.Where(x => x.Applicant.Email.Contains(i.Applicant.Email));
                if (!i.Applicant.Name.IsNullOrEmpty())
                    query = query.Where(x => x.Applicant.Name.Contains(i.Applicant.Name));
                if (!i.Applicant.Country.IsNullOrEmpty())
                    query = query.Where(x => x.Applicant.Country.Contains(i.Applicant.Country));
                if (i.Applicant.MailAttempts != default(int))
                    query = query.Where(x => x.Applicant.MailAttempts == i.Applicant.MailAttempts);
            }

            if (i.Appointment != null)
            {
                if (i.Appointment.From != default(DateTime))
                    query = query.Where(x => x.Appointment.From.Date == i.Appointment.From.Date);
                if (i.Appointment.To != default(DateTime))
                    query = query.Where(x => x.Appointment.To.Date == i.Appointment.To.Date);
            }
            return query;
        }
        private IQueryable<AvailableTime> BuildFindAvailableTimeQuery(IAvailableTime a, IQueryable<AvailableTime> query)
        {
            if (a.From != default(DateTime))
                query = query.Where(x => x.From.Date == a.From.Date);
            if (a.To != default(DateTime))
                query = query.Where(x => x.To.Date == a.To.Date);
            return query;
        }
        private IQueryable<Appointment> BuildFindAppointmentQuery(IAppointment a, IQueryable<Appointment> query)
        {
            if (a.From != default(DateTime))
                query = query.Where(x => x.From.Date == a.From.Date);
            if (a.To != default(DateTime))
                query = query.Where(x => x.To.Date == a.To.Date);
            return query;
        }
        private IQueryable<Applicant> BuildFindApplicantQuery(IApplicant a, IQueryable<Applicant> query)
        {
            if (!a.Email.IsNullOrEmpty())
                query = query.Where(x => x.Email.Contains(a.Email));
            if (!a.Name.IsNullOrEmpty())
                query = query.Where(x => x.Name.Contains(a.Name));
            if (!a.Country.IsNullOrEmpty())
                query = query.Where(x => x.Country.Contains(a.Country));
            if (a.MailAttempts != default(int))
                query = query.Where(x => x.MailAttempts == a.MailAttempts);
            return query;
        }
        #endregion

        #region Find Multiple Methods

        private ICollection<T> FindMultipleResults<T>(IQueryable<T> query) where T : class, IEntity
        {
            var result = query.ToList().Distinct();
            if (result.Count() > 0)
                return new List<T>(result);
            else
                throw new Exception(string.Format("Found no result for {0}", typeof(T).Name));
        }
        // Create methods for all the different classes, where you should be able to get multiple specific elements.

        // e.g
        /*
        internal ICollection<YourDomainClass> FindMultipleYourDomainClass(IYourDomainClass y)
        {
            var query = repo.YourDomainClassInPlural.AsQueryable();
            query = BuildFindYourDomainClassQuery(y, query);

            return FindMultipleResults(query);
        }
        */
        internal ICollection<Interviewer> FindMultipleInterviewers(IInterviewer i)
        {
            var query = repo.Interviewers.AsQueryable();
            query = BuildFindInterviewerQuery(i, query);

            return FindMultipleResults(query);
        }
        internal ICollection<Interview> FindMultipleInterviews(IInterview i)
        {
            var query = repo.Interviews.AsQueryable();
            query = BuildFindInterviewQuery(i, query);

            return FindMultipleResults(query);
        }
        internal ICollection<AvailableTime> FindMultipleAvailableTimes(IAvailableTime a)
        {
            var query = repo.AvailableTimes.AsQueryable();
            query = BuildFindAvailableTimeQuery(a, query);

            return FindMultipleResults(query);
        }
        internal ICollection<Appointment> FindMultipleAppointments(IAppointment a)
        {
            var query = repo.Appointments.AsQueryable();
            query = BuildFindAppointmentQuery(a, query);

            return FindMultipleResults(query);
        }
        internal ICollection<Applicant> FindMultipleApplicants(IApplicant a)
        {
            var query = repo.Applicants.AsQueryable();
            query = BuildFindApplicantQuery(a, query);

            return FindMultipleResults(query);
        }
        internal ICollection<Administrator> FindMultipleAdministrators(IAdministrator a)
        {
            var query = repo.Administrators.AsQueryable();
            query = BuildFindAdministratorQuery(a, query);

            return FindMultipleResults(query);
        }
        #endregion

        #region Find Single Methods

        private T FindAResult<T>(IQueryable<T> query) where T : class, IEntity
        {
            var result = query.ToList().Distinct();
            if (result.Count() == 1)
                return result.First();
            else if (result.Count() > 1)
                throw new Exception(string.Format("More than 1 result found when searching for a {0}", typeof(T).Name));
            else
                throw new Exception(string.Format("No results found when searching for a {0}", typeof(T).Name));
        }
        // Create methods for all the different classes, where you should be able to get one specific element.

        // e.g
        /*
        internal IYourDomainClass FindYourDomainClass(IYourDomainClass y)
        {
            var query = repo.YourDomainClassAsPlural.AsQueryable();
            query = BuildFindYourDomainClassQuery(y, query);

            return FindAResult(query);
        }
        */

        internal IInterviewer FindInterviewer(IInterviewer i)
        {
            var query = repo.Interviewers.AsQueryable();
            query = BuildFindInterviewerQuery(i, query);

            return FindAResult(query);
        }

        internal IInterview FindInterview(IInterview i)
        {
            var query = repo.Interviews.AsQueryable();
            query = BuildFindInterviewQuery(i, query);

            return FindAResult(query);
        }

        internal IAvailableTime FindAvailableTime(IAvailableTime a)
        {
            var query = repo.AvailableTimes.AsQueryable();
            query = BuildFindAvailableTimeQuery(a, query);

            return FindAResult(query);
        }

        internal IAppointment FindAppointment(IAppointment a)
        {
            var query = repo.Appointments.AsQueryable();
            query = BuildFindAppointmentQuery(a, query);

            return FindAResult(query);
        }

        internal IApplicant FindApplicant(IApplicant a)
        {
            var query = repo.Applicants.AsQueryable();
            query = BuildFindApplicantQuery(a, query);

            return FindAResult(query);
        }

        internal IAdministrator FindAdministrator(IAdministrator a)
        {
            var query = repo.Administrators.AsQueryable();
            query = BuildFindAdministratorQuery(a, query);

            return FindAResult(query);
        }
        #endregion

        #region Add Methods

        // There should be one method for each case in the switch on the Generic version, or each overload in the Serializable version

        // e.g
        /*
        internal bool AddYourDomainClass(IYourDomainClass y)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;
            
            entry = repo.Add(y);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Added);
        }        
         */

        internal bool AddInterviewer(IInterviewer i)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = repo.Add(i);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Added);
        }

        internal bool AddInterview(IInterview i)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = repo.Add(i);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Added);
        }

        internal bool AddAvailableTime(IAvailableTime a)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = repo.Add(a);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Added);
        }

        internal bool AddAppointment(IAppointment a)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = repo.Add(a);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Added);
        }

        internal bool AddApplicant(IApplicant a)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = repo.Add(a);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Added);
        }

        internal bool AddAdministrator(IAdministrator a)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = repo.Add(a);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Added);
        }

        #endregion

        #region Update Methods

        // There should be one method for each case in the switch on the Generic version, or each overload in the Serializable version

        // e.g
        /*
        internal bool UpdateYourDomainClass(IYourDomainClass y)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;
            
            entry = repo.Update(y);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Modified);
        }        
         */

        internal bool UpdateInterviewer(IInterviewer i)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = repo.Update(i);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Modified);
        }

        internal bool UpdateInterview(IInterview i)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = repo.Update(i);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Modified);
        }

        internal bool UpdateAvailableTime(IAvailableTime a)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = repo.Update(a);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Modified);
        }

        internal bool UpdateAppointment(IAppointment a)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = repo.Update(a);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Modified);
        }

        internal bool UpdateApplicant(IApplicant a)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = repo.Update(a);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Modified);
        }

        internal bool UpdateAdministrator(IAdministrator a)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = repo.Update(a);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Modified);
        }
        #endregion

        #region Delete Methods

        // There should be one method for each case in the switch on the Generic version, or each overload in the Serializable version

        // e.g
        /*
        internal bool DeleteYourDomainClass(IYourDomainClass y)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;
            
            entry = repo.Remove(y);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Deleted);
        }        
         */

        internal bool DeleteInterviewer(IInterviewer i)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = repo.Remove(i);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Deleted);
        }

        internal bool DeleteInterview(IInterview i)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = repo.Remove(i);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Deleted);
        }

        internal bool DeleteAvailableTime(IAvailableTime a)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = repo.Remove(a);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Deleted);
        }

        internal bool DeleteAppointment(IAppointment a)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = repo.Remove(a);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Deleted);
        }

        internal bool DeleteApplicant(IApplicant a)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = repo.Remove(a);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Deleted);
        }

        internal bool DeleteAdministrator(IAdministrator a)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = repo.Remove(a);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Deleted);
        }
        #endregion
    }
}
