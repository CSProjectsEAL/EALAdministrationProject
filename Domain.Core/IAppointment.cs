using Repository.Core;
using System;

namespace Domain.Core
{
    public interface IAppointment : IEntity
    {
        DateTime From { get; set; }
        DateTime To { get; set; }
        bool BookedStatus { get; set; }
    }
}