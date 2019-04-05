using Repository.Core;

namespace Domain.Core
{
    public interface IInterview : IEntity
    {
        IInterviewer Interviewer { get; set; }
        IApplicant Applicant { get; set; }
        IAppointment Appointment { get; set; }
    }
}