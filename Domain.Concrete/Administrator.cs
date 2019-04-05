using Domain.Core;
using Domain.Core.Enums;

namespace Domain.Concrete
{
    public class Administrator : IAdministrator
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Clearance AccessLevel { get; set; }
        public int Id { get; set; }
        public byte[] Version { get; set; }
    }
}