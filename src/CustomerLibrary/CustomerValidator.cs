using System;
using System.Text.RegularExpressions;
using FluentValidation;

namespace CustomerLibrary
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName).Length(0, 50).When(customer => customer.FirstName != null)
                .WithMessage("First name should not be longer than 50 chars");
            RuleFor(customer => customer.LastName).NotNull().Length(0, 50)
                .WithMessage("Last name should not be null or longer than 50 chars");
            RuleFor(customer => customer.Addresses).NotNull().NotEmpty()
                .WithMessage("Addresses list must be not null and not empty");
            RuleFor(customer => customer.PhoneNumber).Must(BeInE164Format).When(customer => customer.PhoneNumber != null)
                .WithMessage("Phone number must be in E.164 format");
            RuleFor(customer => customer.Email).Must(BeValidEmail).When(customer => customer.Email != null)
                .WithMessage("Email must be valid");
            RuleFor(customer => customer.Notes).NotNull().NotEmpty()
                .WithMessage("Notes list must be not null and not empty");
        }

        private bool BeInE164Format(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^\+?[1-9]\d{1,14}$");
        }

        private bool BeValidEmail(string email)
        {
            return Regex.IsMatch(email,
                @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");
        }
    }
}
