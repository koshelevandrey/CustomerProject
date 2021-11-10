using System;
using System.Collections.Generic;

namespace CustomerLibrary
{
    public class AddressValidator
    {
        public static List<string> Validate(Address address)
        {
            List<string> errors = new List<string>();
            if (address.Line.Length > 100)
            {
                errors.Add("Line is longer than 100 char");
            }
            if ((address.Line2 != null) && (address.Line2.Length > 100))
            {
                errors.Add("Line 2 is longer than 100 char");
            }
            if (address.City.Length > 50)
            {
                errors.Add("City is longer than 50 char");
            }
            if (address.PostalCode.Length > 6)
            {
                errors.Add("Postal code is longer than 6 char");
            }
            if (address.State.Length > 20)
            {
                errors.Add("State is longer than 20 char");
            }
            if (!(address.Country == "United States" || address.Country == "Canada"))
            {
                errors.Add("Wrong country name (only United States and Canada are accepted)");
            }

            return errors;
        }
    }
}
