using Domain.Core;

namespace Domain.Concrete
{
    public class Interview : IInterview
    {
        public IInterviewer Interviewer { get; set; }
        public IApplicant Applicant { get; set; }
        public IAppointment Appointment { get; set; }
        public int Id { get; set; }
        public byte[] Version { get; set; }
    }
}