using System;

namespace CustomerLibrary
{
    public class Address
    {
        public string Line { get; set; }
        public string Line2 { get; set; }
        public AddressType Type { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public Address(string line, AddressType type, string city, string postalCode, string state, string country)
        {
            Line = line;
            Type = type;
            City = city;
            PostalCode = postalCode;
            State = state;
            Country = country;
        }
    }
}
