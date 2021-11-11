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

            Assert.Equal("Pushkin street", address.Line);
            Assert.Equal("5 house", address.Line2);
            Assert.Equal(AddressType.Billing, address.Type);
            Assert.Equal("Moscow", address.City);
            Assert.Equal("5724", address.PostalCode);
            Assert.Equal("Unknown", address.State);
            Assert.Equal("United States", address.Country);
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
            Assert.Equal(6, result.Errors.Count);

            Assert.Equal("Line should not be null or longer than 100 chars", result.Errors[0].ErrorMessage);
            Assert.Equal("Line 2 should not be longer than 100 chars", result.Errors[1].ErrorMessage);
            Assert.Equal("City should not be null or longer than 50 chars", result.Errors[2].ErrorMessage);
            Assert.Equal("Postal code should not be null or longer than 6 chars", result.Errors[3].ErrorMessage);
            Assert.Equal("State should not be null or longer than 6 chars", result.Errors[4].ErrorMessage);
            Assert.Equal("Wrong country name (only United States and Canada are accepted)", result.Errors[5].ErrorMessage);
        }
    }
}
