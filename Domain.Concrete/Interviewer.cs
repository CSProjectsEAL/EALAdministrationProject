using System.Collections.Generic;
using Domain.Core;
using Domain.Core.Enums;

namespace Domain.Concrete
{
    public class Interviewer : IInterviewer
    {
        public string Department { get; set; }
        public ICollection<IApplicant> ApplicantsToInterview { get; set; }
        public ICollection<IAvailableTime> AvailableTimes { get; set; }
        public ICollection<IInterview> Interviews { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Clearance AccessLevel { get; set; }
        public int Id { get; set; }
        public byte[] Version { get; set; }

        public Interviewer()
        {
            ApplicantsToInterview = new List<IApplicant>();
            AvailableTimes = new List<IAvailableTime>();
            Interviews = new List<IInterview>();
        }
    }
}