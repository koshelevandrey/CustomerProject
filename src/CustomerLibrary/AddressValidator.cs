using System;
using FluentValidation;

namespace CustomerLibrary
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.Line).NotNull().Length(0, 100)
                .WithMessage("Line should not be null or longer than 100 chars");
            RuleFor(address => address.Line2).Length(0, 100).When(address => address.Line2 != null)
                .WithMessage("Line 2 should not be longer than 100 chars");
            RuleFor(address => address.City).NotNull().Length(0, 50)
                .WithMessage("City should not be null or longer than 50 chars");
            RuleFor(address => address.PostalCode).NotNull().Length(0, 6)
                .WithMessage("Postal code should not be null or longer than 6 chars");
            RuleFor(address => address.State).NotNull().Length(0, 20)
                .WithMessage("State should not be null or longer than 6 chars");
            RuleFor(address => address.Country).NotNull().Must(BeValidCountry)
                .WithMessage("Wrong country name (only United States and Canada are accepted)");
        }

        private bool BeValidCountry(string country)
        {
            return country == "United States" || country == "Canada";
        }
    }
}
