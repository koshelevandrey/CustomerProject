using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CustomerLibrary
{
    public class CustomerValidator
    {
        public static List<string> Validate(Customer customer)
        {
            List<string> errors = new List<string>();
            if ((customer.FirstName != null) && (customer.FirstName.Length > 50))
            {
                errors.Add("First name is longer than 50 char");
            }
            if (customer.LastName.Length > 50)
            {
                errors.Add("Last name is longer than 50 char");
            }
            if ((customer.Addresses == null) || (customer.Addresses.Count == 0))
            {
                errors.Add("Addresses list must contain at least 1 address");
            }
            if ((customer.PhoneNumber != null) && !(Regex.IsMatch(customer.PhoneNumber, @"^\+?[1-9]\d{1,14}$")))
            {
                errors.Add("Phone number is not in E.164 format");
            }
            if ((customer.Email != null) && !(Regex.IsMatch(customer.Email,
                @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$")))
            {
                errors.Add("Email is not valid");
            }
            if ((customer.Notes == null) || (customer.Notes.Count == 0))
            {
                errors.Add("Notes cannot be empty, at least 1 note must be provided");
            }

            return errors;
        }
    }
}
