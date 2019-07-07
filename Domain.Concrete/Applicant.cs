using Domain.Core;
using Domain.Core.Enums;

namespace Domain.Concrete
{
    public class Applicant : IApplicant
    {
        public string Country { get; set; }
        public bool ActivityState { get; set; }
        public int MailAttempts { get; set; }
        public bool Hasinterviewer { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Clearance AccessLevel { get; set; }
        public int Id { get; set; }
        public byte[] Version { get; set; }
    }
}