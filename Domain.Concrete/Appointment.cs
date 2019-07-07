using System;
using Domain.Core;

namespace Domain.Concrete
{
    public class Appointment : IAppointment
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool BookedStatus { get; set; }
        public int Id { get; set; }
        public byte[] Version { get; set; }
    }
}