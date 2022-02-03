namespace Dotnetos.Conference.WebApi.Entities
{
    //public class OnlineSpeaker : Speaker
    //{
    //    public bool OnlineSetupTested { get; set; }

    //    public OnlineSpeaker(string firstName, string lastName, string company, bool setupTested) : base(firstName, lastName, company)
    //    {
    //        OnlineSetupTested = setupTested;
    //    }
    //}

    public record OnlineSpeaker(string FirstName, string LastName, string Company, bool OnlineSetupTested) : Speaker(FirstName, LastName, Company);
}