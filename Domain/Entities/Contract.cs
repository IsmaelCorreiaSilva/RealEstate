
namespace Domain.Entities
{
    public class Contract
    {
        public Contract(Person locator, Person renter, Immobile immobile, DateTime startContract, DateTime endContract, decimal rentalValue)
        {
            Locator = locator;
            Renter = renter;
            Immobile = immobile;
            Status = EContractStatus.OPENED; 
            StartContract = startContract;
            EndContract = endContract;
            RentalValue = rentalValue;
            BailInsurance = new Installment().CreateBailInsuranceInstallment(rentalValue);
            MinimumContract = AddMininumOfOneYear();
            //Installments = new List<Installment>();

        }

        public Person Locator { get; private set; }
        public Person Renter { get; private set; }
        public Immobile Immobile { get; private set; }
        public EContractStatus Status { get; private set; }
        public DateTime StartContract { get; private set; }
        public DateTime EndContract { get; private set; }
        public DateTime MinimumContract { get; private set; }
        public decimal RentalValue { get; private set; }
        public Installment BailInsurance { get; private set; }
        public ICollection<Installment> Installments { get; private set; }
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
            if (BailInsurance.Status == EInstallmentStatus.PAID)
                return true;

            return false;
        }
        public void PayBailInsurance(decimal value)
        {
            BailInsurance.Pay(value);
        }
        public void CreateInstallments(int numberInstallments)
        {
            Installments = new List<Installment>();
            for (int i = 0; i < numberInstallments; i++)
            {
                Installments.Add(new Installment().CreateInstallment(RentalValue, DateTime.Today.AddMonths(i + 1)));
            }
        }
    }
}
