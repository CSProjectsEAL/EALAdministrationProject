using System;
using System.Collections.Generic;
using Domain.Core;

namespace Domain.Concrete
{
    public class AvailableTime : IAvailableTime
    {
        public ICollection<IAppointment> Appointments { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Id { get; set; }
        public byte[] Version { get; set; }
    }
}