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
            List<string> errors = AddressValidator.Validate(address);

            Assert.True(errors.Count == 0);
        }

        [Fact]
        public void ShouldNotBeAbleToValidateAddress()
        {
            Address address = new Address(new string('a', 101), AddressType.Billing,
                new string('a', 51), "5724341", new string('a', 21), "Russia");
            address.Line2 = new string('b', 101);
            List<string> errors = AddressValidator.Validate(address);

            Assert.True(errors.Count == 6);

            Assert.True(errors[0] == "Line is longer than 100 char");
            Assert.True(errors[1] == "Line 2 is longer than 100 char");
            Assert.True(errors[2] == "City is longer than 50 char");
            Assert.True(errors[3] == "Postal code is longer than 6 char");
            Assert.True(errors[4] == "State is longer than 20 char");
            Assert.True(errors[5] == "Wrong country name (only United States and Canada are accepted)");
        }
    }
}
