
using Bogus;
using Domain.Entities;

namespace DomainTests.FakerData
{
    public class ContractFaker : Faker<Contract>
    {
        public ContractFaker(decimal rentalValue)
        {
            RuleFor(c => c.StartContract, DateTime.Today);
            RuleFor(c => c.EndContract, DateTime.Today.AddYears(3));
            RuleFor(c => c.MinimumContract, DateTime.Today.AddYears(1));
            RuleFor(c => c.RentalValue, rentalValue);
            RuleFor(c => c.Immobile, new ImmobileFaker().Generate());
            RuleFor(c => c.Renter, new PersonFaker().Generate());
            RuleFor(c => c.Locator, new PersonFaker().Generate());
            RuleFor(c => c.Status, EContractStatus.OPENED);
            RuleFor(c => c.BailInsurance, new Installment().CreateBailInsuranceInstallment(rentalValue));
            RuleFor(c => c.Installments, new List<Installment>());
        }
        public ContractFaker(decimal rentalValue, int years)
        {
            RuleFor(c => c.StartContract, DateTime.Today);
            RuleFor(c => c.EndContract, DateTime.Today.AddYears(3));
            RuleFor(c => c.MinimumContract, DateTime.Today.AddYears(1));
            RuleFor(c => c.RentalValue, rentalValue);
            RuleFor(c => c.Immobile, new ImmobileFaker().Generate());
            RuleFor(c => c.Renter, new PersonFaker(years).Generate());
            RuleFor(c => c.Locator, new PersonFaker(years).Generate());
            RuleFor(c => c.Status, EContractStatus.OPENED);
            RuleFor(c => c.BailInsurance, new Installment().CreateBailInsuranceInstallment(rentalValue));
        }
        public ContractFaker(decimal rentalValue, string cpf)
        {
            RuleFor(c => c.StartContract, DateTime.Today);
            RuleFor(c => c.EndContract, DateTime.Today.AddYears(3));
            RuleFor(c => c.MinimumContract, DateTime.Today.AddYears(1));
            RuleFor(c => c.RentalValue, rentalValue);
            RuleFor(c => c.Immobile, new ImmobileFaker().Generate());
            RuleFor(c => c.Renter, new PersonFaker(cpf).Generate());
            RuleFor(c => c.Locator, new PersonFaker(cpf).Generate());
            RuleFor(c => c.Status, EContractStatus.OPENED);
            RuleFor(c => c.BailInsurance, new Installment().CreateBailInsuranceInstallment(rentalValue));
            RuleFor(c => c.Installments, new List<Installment>());
        }
        public ContractFaker(decimal rentalValue, int years, int days)
        {
            RuleFor(c => c.StartContract, DateTime.Today);
            RuleFor(c => c.EndContract, DateTime.Today.AddYears(3));
            RuleFor(c => c.MinimumContract, DateTime.Today.AddYears(1));
            RuleFor(c => c.RentalValue, rentalValue);
            RuleFor(c => c.Immobile, new ImmobileFaker(days).Generate());
            RuleFor(c => c.Renter, new PersonFaker().Generate());
            RuleFor(c => c.Locator, new PersonFaker().Generate());
            RuleFor(c => c.Status, EContractStatus.OPENED);
            RuleFor(c => c.BailInsurance, new Installment().CreateBailInsuranceInstallment(rentalValue));
            RuleFor(c => c.Installments, new List<Installment>());
        }
        public ContractFaker(decimal rentalValue, DateTime startContract, DateTime endContract)
        {
            RuleFor(c => c.StartContract, startContract);
            RuleFor(c => c.EndContract, endContract);
            RuleFor(c => c.MinimumContract, DateTime.Today.AddYears(1));
            RuleFor(c => c.RentalValue, rentalValue);
            RuleFor(c => c.Immobile, new ImmobileFaker().Generate());
            RuleFor(c => c.Renter, new PersonFaker().Generate());
            RuleFor(c => c.Locator, new PersonFaker().Generate());
            RuleFor(c => c.Status, EContractStatus.OPENED);
            RuleFor(c => c.BailInsurance, new Installment().CreateBailInsuranceInstallment(rentalValue));
            RuleFor(c => c.Installments, new List<Installment>());
        }
    }
}