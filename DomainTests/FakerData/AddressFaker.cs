using Bogus;
using Domain.Entities;

namespace DomainTests.FakerData
{
    public class AddressFaker: Faker<Address>
    {
        public AddressFaker()
        {
            RuleFor(a => a.ZipCode, b => b.Address.ZipCode());
            RuleFor(a => a.Street, b => b.Address.StreetName());
            RuleFor(a => a.Number, b => b.Address.BuildingNumber());
            RuleFor(a => a.District, b => b.Lorem.Sentence(20));
            RuleFor(a => a.City, b => b.Address.City());
            RuleFor(a => a.State, b => b.Address.State());
            RuleFor(a => a.Complement, b => b.Lorem.Sentence(20));
        }
    }
}
