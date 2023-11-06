
namespace Domain.Entities
{
    public class Installment
    {
        public Installment() 
        {   
        }
        public string Number  { get; private set; }
        public decimal Value { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime Payday { get; private set;}

        public Installment CreateBailInsuranceInstallment(decimal rentaValue) 
        {
            Number = "Unica";
            Value = rentaValue * 2;
            DueDate = DateTime.Today.AddDays(7);

            return this;
        }
    }
}
