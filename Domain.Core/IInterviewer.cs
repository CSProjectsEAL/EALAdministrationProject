using System.Collections.Generic;

namespace Domain.Core
{
    public interface IInterviewer : IUser
    {
        string Department { get; set; }
        ICollection<IApplicant> ApplicantsToInterview { get; set; }
        ICollection<IAvailableTime> AvailableTimes { get; set; }
        ICollection<IInterview> Interviews { get; set; }
    }
}