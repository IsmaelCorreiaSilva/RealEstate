
using Domain.Exceptions;

namespace Domain.Entities
{
    public class Installment
    {
        public Installment() 
        {
            Number = "";
            Value = 0;
            DueDate = DateTime.MinValue;
            //Payday = DateTime;
        }
        public string Number  { get; private set; }
        public string Status { get; set; }
        public decimal Value { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime Payday { get; private set;}

        public Installment CreateBailInsuranceInstallment(decimal rentaValue) 
        {
            Number = "Only";
            Value = rentaValue * 2;
            Status = "Opened";
            DueDate = DateTime.Today.AddDays(7);

            return this;
        }
        public void Pay(decimal value) 
        {
            if(value < Value)
                throw new InstallmentDomainExpection("Valor informado é menor que parcela!");

            Status = "Paid";
            Payday = DateTime.Today;
        }
    }
}
