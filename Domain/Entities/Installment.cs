
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
        }
        public string Number  { get; private set; }
        public EInstallmentStatus Status { get; set; }
        public decimal Value { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime Payday { get; private set;}

        public Installment CreateBailInsuranceInstallment(decimal value) 
        {
            Number = "Only";
            Value = value * 2;
            Status = EInstallmentStatus.OPENED;
            DueDate = CreateDueDate(DateTime.Today);

            return this;
        }
        public DateTime CreateDueDate(DateTime date)
        {
            date = date.AddDays(7);

            if(date.DayOfWeek == DayOfWeek.Sunday) 
                return date.AddDays(1);

            if(date.DayOfWeek == DayOfWeek.Saturday)
                return date.AddDays(2);
            
            return date;
        }
        public bool Pay(decimal value)
        {
            //if (value < Value)
            //    throw new InstallmentDomainExpection("Valor informado é menor que parcela!");
            if (value < Value)
                return false;
            
            Status = EInstallmentStatus.PAID;
            Payday = DateTime.Today;
            return true;
        }
        public bool PaymentMadeLate()
        {
            if (DueDate < DateTime.Today)
                return true;

            return false;
        }
        public Installment CreateInstallment(decimal value, DateTime date)
        {
            Number = CreateNumber(date);
            Value = value;
            Status = EInstallmentStatus.OPENED;
            DueDate = CreateDueDate(date);

            return this;
        }
        private string CreateNumber(DateTime date)
        {
            return date.Year + "/" + date.Month;
        }
    }
}
