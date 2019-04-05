using Repository.Core;
using System;
using System.Collections.Generic;

namespace Domain.Core
{
    public interface IAvailableTime : IEntity
    {
        ICollection<IAppointment> Appointments { get; set; }
        DateTime From { get; set; }
        DateTime To { get; set; }
    }
}