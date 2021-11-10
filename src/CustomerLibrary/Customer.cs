using System;
using System.Collections.Generic;

namespace CustomerLibrary
{
    public class Customer : Person
    {
        public List<Address> Addresses { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<string> Notes { get; set; }
        public decimal? TotalPurchasesAmount { get; set; }

        public Customer(string lastName, List<Address> addresses, List<string> notes) : base(lastName)
        {
            Addresses = addresses;
            Notes = notes;
        }
    }
}
