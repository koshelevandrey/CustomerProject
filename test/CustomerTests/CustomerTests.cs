using System;
using Xunit;
using CustomerLibrary;
using System.Collections.Generic;

namespace CustomerTests
{
    public class CustomerTests
    {
        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            List<Address> addresses = new List<Address>();
            Address address = new Address("Pushkin street", AddressType.Billing, "Moscow", "5724", "Unknown", "Russia");
            address.Line2 = "5 house";
            addresses.Add(address);
            List<string> notes = new List<string>();
            notes.Add("note 1");
            notes.Add("note 2");
            Customer customer = new Customer("Petrov", addresses, notes);
            customer.PhoneNumber = "+195534912";
            customer.Email = "petrov123@mail.ru";
            customer.TotalPurchasesAmount = .01m;

            Assert.NotNull(customer);
        }

        [Fact]
        public void ShouldNotBeAbleToMakeTotalPurchaseAmountNull()
        {
            List<Address> addresses = new List<Address>();
            Address address = new Address("Pushkin street", AddressType.Billing, "Moscow", "5724", "Unknown", "United States");
            address.Line2 = "5 house";
            addresses.Add(address);
            List<string> notes = new List<string>();
            notes.Add("note 1");
            Customer customer = new Customer("Petrov", addresses, notes);

            Assert.True(customer.TotalPurchasesAmount == null);
        }

        [Fact]
        public void ShouldBeAbleToValidateCustomer()
        {
            List<Address> addresses = new List<Address>();
            Address address = new Address("Pushkin street", AddressType.Billing, "Moscow", "5724", "Unknown", "United States");
            address.Line2 = "5 house";
            addresses.Add(address);
            List<string> notes = new List<string>();
            notes.Add("note 1");
            notes.Add("note 2");
            Customer customer = new Customer("Petrov", addresses, notes);
            customer.FirstName = "Ivan";
            customer.PhoneNumber = "+195534912";
            customer.Email = "petrov123@mail.ru";
            customer.TotalPurchasesAmount = .01m;

            List<string> errors = customer.Validate();

            Assert.True(errors.Count == 0);
        }

        [Fact]
        public void ShouldNotBeAbleToValidateCustomer()
        {
            List<Address> addresses = new List<Address>();
            List<string> notes = new List<string>();
            Customer customer = new Customer(new string('b', 51), addresses, notes);
            customer.FirstName = new string('a', 51);
            customer.PhoneNumber = "0123";
            customer.Email = "petrov123-@-mail.ru.";

            List<string> errors = customer.Validate();

            Assert.True(errors.Count == 6);

            Assert.True(errors[0] == "First name is longer than 50 char");
            Assert.True(errors[1] == "Last name is longer than 50 char");
            Assert.True(errors[2] == "Addresses list must contain at least 1 address");
            Assert.True(errors[3] == "Phone number is not in E.164 format");
            Assert.True(errors[4] == "Email is not valid");
            Assert.True(errors[5] == "Notes cannot be empty, at least 1 note must be provided");
        }
    }
}
