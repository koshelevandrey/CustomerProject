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
            customer.FirstName = "Ivan";
            customer.PhoneNumber = "+195534912";
            customer.Email = "petrov123@mail.ru";
            customer.TotalPurchasesAmount = .01m;

            Assert.NotNull(customer);

            Assert.Equal("Ivan", customer.FirstName);
            Assert.Equal("Petrov", customer.LastName);
            Assert.Equal(addresses, customer.Addresses);
            Assert.Equal(address, customer.Addresses[0]);
            Assert.Equal(notes, customer.Notes);
            Assert.Equal("note 1", customer.Notes[0]);
            Assert.Equal("note 2", customer.Notes[1]);
            Assert.Equal("+195534912", customer.PhoneNumber);
            Assert.Equal("petrov123@mail.ru", customer.Email);
            Assert.Equal(.01m, customer.TotalPurchasesAmount);
        }

        [Fact]
        public void ShouldBeAbleToMakeTotalPurchaseAmountNull()
        {
            List<Address> addresses = new List<Address>();
            Address address = new Address("Pushkin street", AddressType.Billing, "Moscow", "5724", "Unknown", "United States");
            address.Line2 = "5 house";
            addresses.Add(address);
            List<string> notes = new List<string>();
            notes.Add("note 1");
            Customer customer = new Customer("Petrov", addresses, notes);

            Assert.Null(customer.TotalPurchasesAmount);
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

            List<string> errors = CustomerValidator.Validate(customer);

            Assert.Empty(errors);
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

            List<string> errors = CustomerValidator.Validate(customer);

            Assert.Equal(6, errors.Count);

            Assert.Equal("First name is longer than 50 char", errors[0]);
            Assert.Equal("Last name is longer than 50 char", errors[1]);
            Assert.Equal("Addresses list must contain at least 1 address", errors[2]);
            Assert.Equal("Phone number is not in E.164 format", errors[3]);
            Assert.Equal("Email is not valid", errors[4]);
            Assert.Equal("Notes cannot be empty, at least 1 note must be provided", errors[5]);
        }
    }
}
