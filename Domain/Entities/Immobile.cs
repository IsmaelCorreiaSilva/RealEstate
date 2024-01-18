

namespace Domain.Entities
{
    public class Immobile
    {
        public Immobile()
        {
            
        }
        public Immobile(DateTime inspectionDate, Address address)
        {
            Address = address;
            InspectionDate = inspectionDate;
            Status = EImmobileStatus.ACTIVE;
        }

        //public string PropertyCode { get; private set; }
        public DateTime InspectionDate { get; private set; }
        public EImmobileStatus Status { get; set; } 
        public Address Address { get; private set; }

        public bool InspectionIsValid()
        {
            return (DateTime.Today - InspectionDate).Days <= 7;
        }
    }
}
