using System;
using Xunit;
using CustomerLibrary;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;

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

            Assert.True(customer.FirstName == "Ivan");
            Assert.True(customer.LastName == "Petrov");
            Assert.True(customer.Addresses == addresses);
            Assert.True(customer.Addresses[0] == address);
            Assert.True(customer.Notes == notes);
            Assert.True(customer.Notes[0] == "note 1");
            Assert.True(customer.PhoneNumber == "+195534912");
            Assert.True(customer.Email == "petrov123@mail.ru");
            Assert.True(customer.TotalPurchasesAmount == .01m);
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

            CustomerValidator validator = new CustomerValidator();
            ValidationResult result = validator.Validate(customer);

            Assert.True(result.IsValid);
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

            CustomerValidator validator = new CustomerValidator();
            ValidationResult result = validator.Validate(customer);

            Assert.True(!result.IsValid);
            Assert.True(result.Errors.Count == 6);

            Assert.True(result.Errors[0].ErrorMessage == "First name should not be longer than 50 chars");
            Assert.True(result.Errors[1].ErrorMessage == "Last name should not be null or longer than 50 chars");
            Assert.True(result.Errors[2].ErrorMessage == "Addresses list must be not null and not empty");
            Assert.True(result.Errors[3].ErrorMessage == "Phone number must be in E.164 format");
            Assert.True(result.Errors[4].ErrorMessage == "Email must be valid");
            Assert.True(result.Errors[5].ErrorMessage == "Notes list must be not null and not empty");
        }
    }
}
