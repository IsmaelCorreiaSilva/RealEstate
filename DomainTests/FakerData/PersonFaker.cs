
using Bogus;
using Bogus.Extensions.Brazil;

namespace DomainTests.FakerData
{
    public class PersonFaker : Faker<Domain.Entities.Person>
    {
        public PersonFaker()
        {
            RuleFor(p => p.Document, b => b.Person.Cpf());
            RuleFor(p => p.Name, b => b.Person.FullName);
            RuleFor(p => p.BirthDate, b => b.Date.Past(100, DateTime.Today.AddYears(-18)));
        }
        public PersonFaker(int years)
        {
            RuleFor(p => p.Document, b => b.Person.Cpf());
            RuleFor(p => p.Name, b => b.Person.FullName);
            RuleFor(p => p.BirthDate, b => DateTime.Today.AddYears(years));
        }
        public PersonFaker(string cpf)
        {
            RuleFor(p => p.Document, cpf);
            RuleFor(p => p.Name, b => b.Person.FullName);
            RuleFor(p => p.BirthDate, b => b.Date.Past(100, DateTime.Today.AddYears(-18)));
        }
    }
}
