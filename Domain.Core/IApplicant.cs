namespace Domain.Core
{
    public interface IApplicant : IUser
    {
        string Country { get; set; }
        bool ActivityState { get; set; }
        int MailAttempts { get; set; }
        bool Hasinterviewer { get; set; }
    }
}