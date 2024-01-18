namespace Domain.Entities
{
    public class Address
    {
        public Address() { }
        public Address(string zipCode, string street, string number, string district, string city, string state, string? complement)
        {
            ZipCode = zipCode;
            Street = street;
            Number = number;
            District = district;
            City = city;
            State = state;
            Complement = complement;
        }

        public string ZipCode { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string? Complement { get; private set; }
    }
}