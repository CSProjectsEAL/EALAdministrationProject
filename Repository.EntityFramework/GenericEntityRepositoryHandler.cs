using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Core;

namespace Repository.EntityFramework
{
    public class GenericEntityRepositoryHandler : BaseEntityRepositoryHandler, IGenericRepository
    {
        public GenericEntityRepositoryHandler(EntityRepository repository) : base(repository)
        {

        }

        bool IGenericRepository.Add<T>(T element)
        {
            bool result = false;

            switch (element)
            {
                // Create cases for all the different classes that should be addable to the database.
                // Remember to setup Uniqueness for columns that are not allowed to contain duplicates

                // Example:
                // case IYourDomainClass y:
                //    result = AddYourDomainClass(y);
                //    break;
                case IAdministrator a:
                    result = AddAdministrator(a);
                    break;
                case IApplicant a:
                    result = AddApplicant(a);
                    break;
                case IAppointment a:
                    result = AddAppointment(a);
                    break;
                case IAvailableTime a:
                    result = AddAvailableTime(a);
                    break;
                case IInterview i:
                    result = AddInterview(i);
                    break;
                case IInterviewer i:
                    result = AddInterviewer(i);
                    break;
                default:
                    throw new Exception("ERROR ERROR ERROR");
            }

            return result;
        }

        string IGenericRepository.AddMultiple<T>(ICollection<T> elements)
        {
            List<bool> results = new List<bool>();

            foreach (var element in elements)
            {
                results.Add((this as IGenericRepository).Add(element));
            }

            return GetAmountAdded(results);
        }

        bool IGenericRepository.Delete<T>(T element)
        {
            if (element.Id == 0)
                throw new Exception(string.Format("I need an Id to figure out what to remove"), new ArgumentException("Id of predicate can't be 0"));
            bool result = false;

            switch (element)
            {
                //Create cases for all the different classes that should be updateable in the database.

                // Example:
                // case IYourDomainClass y:
                //    result = DeleteYourDomainClass(y);
                //    break;
                case IAdministrator a:
                    result = DeleteAdministrator(a);
                    break;
                case IApplicant a:
                    result = DeleteApplicant(a);
                    break;
                case IAppointment a:
                    result = DeleteAppointment(a);
                    break;
                case IAvailableTime a:
                    result = DeleteAvailableTime(a);
                    break;
                case IInterview i:
                    result = DeleteInterview(i);
                    break;
                case IInterviewer i:
                    result = DeleteInterviewer(i);
                    break;
                default:
                    throw new Exception("ERROR ERROR ERROR");
            }

            return result;
        }

       

        T IGenericRepository.Find<T>(T predicate)
        {
            IEntity entity = null;
            switch (predicate)
            {
                // Create cases for all the different classes that should be retriable from the database

                // Example:
                // case IYourDomainClass y:
                //    entity = FindYourDomainClass(y);
                //    break;
                case IAdministrator a:
                    entity = FindAdministrator(a);
                    break;
                case IApplicant a:
                    entity = FindApplicant(a);
                    break;
                case IAppointment a:
                    entity = FindAppointment(a);
                    break;
                case IAvailableTime a:
                    entity = FindAvailableTime(a);
                    break;
                case IInterview i:
                    entity = FindInterview(i);
                    break;
                case IInterviewer i:
                    entity = FindInterviewer(i);
                    break;
                default:
                    throw new Exception("ERROR ERROR ERROR");
            }

            return entity as T;
        }

        ICollection<T> IGenericRepository.FindMultiple<T>(T predicate)
        {
            ICollection<T> entities = null;
            switch (predicate)
            {
                // Create cases for all the different classes that should be retriable from the database

                // Example:
                // case IYourDomainClass y:
                //    entities = FindMultipleYourDomainClassInPlural(y) as ICollection<T>;
                //    break;
                case IAdministrator a:
                    entities = FindMultipleAdministrators(a) as ICollection<T>;
                    break;
                case IApplicant a:
                    entities = FindMultipleApplicants(a) as ICollection<T>;
                    break;
                case IAppointment a:
                    entities = FindMultipleAppointments(a) as ICollection<T>;
                    break;
                case IAvailableTime a:
                    entities = FindMultipleAvailableTimes(a) as ICollection<T>;
                    break;
                case IInterview i:
                    entities = FindMultipleInterviews(i) as ICollection<T>;
                    break;
                case IInterviewer i:
                    entities = FindMultipleInterviewers(i) as ICollection<T>;
                    break;
                default:
                    throw new Exception("ERROR ERROR ERROR");
            }

            return entities;
        }

        bool IGenericRepository.Update<T>(T element)
        {
            if (element.Id == 0)
                throw new Exception(string.Format("I need an Id to figure out what to update"), new ArgumentException("Id of predicate can not be 0"));
            bool result = false;

            switch (element)
            {
                //Create cases for all the differnet classes that should be updateable in the database.

                // Example:
                // case IYourDomainClass y:
                //    result = UpdateYourDomainClass(y);
                //    break;
                case IAdministrator a:
                    result = UpdateAdministrator(a);
                    break;
                case IApplicant a:
                    result = UpdateApplicant(a);
                    break;
                case IAppointment a:
                    result = UpdateAppointment(a);
                    break;
                case IAvailableTime a:
                    result = UpdateAvailableTime(a);
                    break;
                case IInterview i:
                    result = UpdateInterview(i);
                    break;
                case IInterviewer i:
                    result = UpdateInterviewer(i);
                    break;
                default:
                    throw new Exception("ERROR ERROR ERROR");
            }
            
            return result;
        }


    }
}
