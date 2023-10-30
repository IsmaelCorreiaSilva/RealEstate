

namespace Domain.Entities
{
    public class Immobile
    {
        public Immobile(string propertyCode, DateTime inspectionDate, Address address)
        {
            InspectionDate = inspectionDate;
            Address = address;
            InspectionDate = inspectionDate;    
        }

        public string PropertyCode { get; private set; }
        public DateTime InspectionDate { get; private set; }
        public Address Address { get; private set; }

        public bool InspectionIsValid()
        {
            return (DateTime.Today - InspectionDate).Days <= 7;
        }
    }
}
