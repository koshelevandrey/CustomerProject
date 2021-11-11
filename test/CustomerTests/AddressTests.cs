using System;
using Xunit;
using CustomerLibrary;
using System.Collections.Generic;

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
            List<string> errors = AddressValidator.Validate(address);

            Assert.Empty(errors);
        }

        [Fact]
        public void ShouldNotBeAbleToValidateAddress()
        {
            Address address = new Address(new string('a', 101), AddressType.Billing,
                new string('a', 51), "5724341", new string('a', 21), "Russia");
            address.Line2 = new string('b', 101);
            List<string> errors = AddressValidator.Validate(address);

            Assert.Equal(6, errors.Count);

            Assert.Equal("Line is longer than 100 char", errors[0]);
            Assert.Equal("Line 2 is longer than 100 char", errors[1]);
            Assert.Equal("City is longer than 50 char", errors[2]);
            Assert.Equal("Postal code is longer than 6 char", errors[3]);
            Assert.Equal("State is longer than 20 char", errors[4]);
            Assert.Equal("Wrong country name (only United States and Canada are accepted)", errors[5]);
        }
    }
}
