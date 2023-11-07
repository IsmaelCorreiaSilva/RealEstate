
using System.Net.Security;

namespace Domain.Entities
{
    public class Contract
    {
        public Contract(Person locator, Person renter, Immobile immobile, DateTime startContract, DateTime endContract, decimal rentalValue)
        {
            Locator = locator;
            Renter = renter;
            Immobile = immobile;
            Status = "open"; 
            StartContract = startContract;
            EndContract = endContract;
            RentalValue = rentalValue;
            BailInsurance = new Installment().CreateBailInsuranceInstallment(rentalValue);
            MinimumContract = AddMininumOfOneYear();

        }

        public Person Locator { get; private set; }
        public Person Renter { get; private set; }
        public Immobile Immobile { get; private set; }
        public string Status { get; private set; }
        public DateTime StartContract { get; private set; }
        public DateTime EndContract { get; private set; }
        public DateTime MinimumContract { get; private set; }
        public decimal RentalValue { get; private set; }
        public Installment BailInsurance { get; private set; }
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
        public bool ContractPeriodIsValid()
        {
            if(StartContract < DateTime.Today)
                return false;

            if(EndContract < DateTime.Today)
                return false;
            
            if(EndContract < MinimumContract)
                return false;
                        
            return true;
        }
        public bool BailInsuranceIsPaid()
        {
            if (BailInsurance.Status.Equals("Paid"))
                return true;

            return false;
        }
        public void PayBailInsurance(decimal value)
        {
            BailInsurance.Pay(value);
        }
    }
}
