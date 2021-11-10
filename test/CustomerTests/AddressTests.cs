using System;
using Xunit;
using CustomerLibrary;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;

namespace CustomerTests
{
    public class AddressTests
    {
        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            Address address = new Address("Pushkin street", AddressType.Billing, "Moscow", "5724", "Unknown", "United States");
            address.Line2 = "5 house";

            Assert.NotNull(address);

            Assert.True(address.Line == "Pushkin street");
            Assert.True(address.Line2 == "5 house");
            Assert.True(address.Type == AddressType.Billing);
            Assert.True(address.City == "Moscow");
            Assert.True(address.PostalCode == "5724");
            Assert.True(address.State == "Unknown");
            Assert.True(address.Country == "United States");
        }

        [Fact]
        public void ShouldBeAbleToValidateAddress()
        {
            Address address = new Address("Pushkin street", AddressType.Billing, "Moscow", "5724", "Unknown", "United States");
            address.Line2 = "5 house";

            AddressValidator validator = new AddressValidator();
            ValidationResult result = validator.Validate(address);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void ShouldNotBeAbleToValidateAddress()
        {
            Address address = new Address(new string('a', 101), AddressType.Billing,
                new string('a', 51), "5724341", new string('a', 21), "Russia");
            address.Line2 = new string('b', 101);

            AddressValidator validator = new AddressValidator();
            ValidationResult result = validator.Validate(address);

            Assert.True(!result.IsValid);
            Assert.True(result.Errors.Count == 6);

            Assert.True(result.Errors[0].ErrorMessage == "Line should not be null or longer than 100 chars");
            Assert.True(result.Errors[1].ErrorMessage == "Line 2 should not be longer than 100 chars");
            Assert.True(result.Errors[2].ErrorMessage == "City should not be null or longer than 50 chars");
            Assert.True(result.Errors[3].ErrorMessage == "Postal code should not be null or longer than 6 chars");
            Assert.True(result.Errors[4].ErrorMessage == "State should not be null or longer than 6 chars");
            Assert.True(result.Errors[5].ErrorMessage == "Wrong country name (only United States and Canada are accepted)");
        }
    }
}
