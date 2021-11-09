using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CustomerProject
{
    public class Customer : Person
    {
        public List<Address> Addresses;
        public string PhoneNumber;
        public string Email;
        public List<string> Notes;
        public decimal? TotalPurchasesAmount;

        public Customer(string lastName, List<Address> addresses, List<string> notes) : base(lastName)
        {
            Addresses = addresses;
            Notes = notes;
        }

        public List<string> Validate()
        {
            List<string> errors = new List<string>();
            if ((FirstName != null) && (FirstName.Length > 50))
            {
                errors.Add("First name is longer than 50 char");
            }
            if (LastName.Length > 50)
            {
                errors.Add("Last name is longer than 50 char");
            }
            if ((Addresses == null) || (Addresses.Count == 0))
            {
                errors.Add("Addresses list must contain at least 1 address");
            }
            if ((PhoneNumber != null) && !(Regex.IsMatch(PhoneNumber, @"^\+?[1-9]\d{1,14}$")))
            {
                errors.Add("Phone number is not in E.164 format");
            }
            if ((Email != null) &&!(Regex.IsMatch(Email,
                @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$")))
            {
                errors.Add("Email is not valid");
            }
            if ((Notes == null) || (Notes.Count == 0))
            {
                errors.Add("Notes cannot be empty, at least 1 note must be provided");
            }

            return errors;
        }
    }
}
