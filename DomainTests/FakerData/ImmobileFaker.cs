
using Bogus;
using Domain.Entities;

namespace DomainTests.FakerData
{
    public class ImmobileFaker:Faker<Immobile>
    {
        public ImmobileFaker() 
        {
            RuleFor(i => i.InspectionDate, DateTime.Today.AddDays(-7));
            RuleFor(i => i.Status, EImmobileStatus.ACTIVE);
            RuleFor(i => i.Address, new AddressFaker().Generate());

        }
        public ImmobileFaker(int days)
        {
            RuleFor(i => i.InspectionDate, DateTime.Today.AddDays(days));
            RuleFor(i => i.Status, EImmobileStatus.ACTIVE);
            RuleFor(i => i.Address, new AddressFaker().Generate());

        }
    }
}
