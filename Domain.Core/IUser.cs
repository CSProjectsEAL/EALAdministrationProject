using Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Repository.Core;

namespace Domain.Core
{
    public interface IUser : IEntity
    {
        string Name { get; set; }
        string Email { get; set; }
        Clearance AccessLevel { get; set; }
    }
}
