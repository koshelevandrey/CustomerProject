using System;
using System.Collections.Generic;

namespace CustomerLibrary
{
    public class Address
    {
        public string Line;
        public string Line2;
        public AddressType Type;
        public string City;
        public string PostalCode;
        public string State;
        public string Country;

        public Address(string line, AddressType type, string city, string postalCode, string state, string country)
        {
            Line = line;
            Type = type;
            City = city;
            PostalCode = postalCode;
            State = state;
            Country = country;
        }

        public List<string> Validate()
        {
            List<string> errors = new List<string>();
            if (Line.Length > 100)
            {
                errors.Add("Line is longer than 100 char");
            }
            if ((Line2 != null) && (Line2.Length > 100))
            {
                errors.Add("Line 2 is longer than 100 char");
            }
            if (City.Length > 50)
            {
                errors.Add("City is longer than 50 char");
            }
            if (PostalCode.Length > 6)
            {
                errors.Add("Postal code is longer than 6 char");
            }
            if (State.Length > 20)
            {
                errors.Add("State is longer than 20 char");
            }
            if (!(Country == "United States" || Country == "Canada"))
            {
                errors.Add("Wrong country name (only United States and Canada are accepted)");
            }

            return errors;
        }
    }
}
