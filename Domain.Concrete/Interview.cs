using Domain.Core;

namespace Domain.Concrete
{
    /// <summary>
    /// Requires a Interviewer, Applicant and Appointment to be assigned before being accepted by the database.
    /// </summary>
    public class Interview : IInterview
    {
        public IInterviewer Interviewer { get; set; }
        public int FK_Interviewer { get; set; }

        public IApplicant Applicant { get; set; }
        public int FK_Applicant { get; set; }

        public IAppointment Appointment { get; set; }
        public int FK_Appointment { get; set; }

        public int Id { get; set; }
        public byte[] Version { get; set; }
    }
}