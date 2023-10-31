

namespace Domain.Entities
{
    public class Immobile
    {
        public Immobile(DateTime inspectionDate, Address address, string status)
        {
            Address = address;
            InspectionDate = inspectionDate;
            Status = status;
        }

        //public string PropertyCode { get; private set; }
        public DateTime InspectionDate { get; private set; }
        public string Status { get; set; }
        public Address Address { get; private set; }

        public bool InspectionIsValid()
        {
            return (DateTime.Today - InspectionDate).Days <= 7;
        }
    }
}
