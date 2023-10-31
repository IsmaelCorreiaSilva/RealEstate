
namespace Domain.Entities
{
    public class Contract
    {
        public Contract(Person locator, Person renter, Immobile immobile, DateTime startContract, DateTime endContract)
        {
            Locator = locator;
            Renter = renter;
            Immobile = immobile;
            Status = "open"; 
            StartContract = startContract;
            EndContract = endContract;
            MinimumDate = AddMininumOfOneYear();

        }

        public Person Locator { get; private set; }
        public Person Renter { get; private set; }
        public Immobile Immobile { get; private set; }
        public string Status { get; private set; }
        public DateTime StartContract { get; private set; }
        public DateTime EndContract { get; private set; }
        public DateTime MinimumDate { get; private set; }
        public bool LocatorIsValid()
        {
           return Locator.IsAdult() && Locator.DocumentIsValid();
        }
        public bool RenterIsValid()
        {
            return Renter.IsAdult() && Renter.DocumentIsValid();
        }
        public bool ImmobileIsValid()
        {
            return Immobile.InspectionIsValid();
        }
        private DateTime AddMininumOfOneYear()
        {
            return DateTime.Today.AddYears(1);
        }
    }
}
