﻿using FluentValidation;

namespace JVB.FinancialControl.Domain.Commands.Users.Validations
{
    public abstract class UserValidation<T> : AbstractValidator<T> where T : UserCommand
    {
        protected void ValidateUsername()
        {
            RuleFor(c => c.Username)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidatePassword()
        {
            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Please ensure you have entered the Password")
                .Length(2, 10).WithMessage("The Name must have between 2 and 150 characters");
        }
        protected void ValidateFirstName()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("Please ensure you have entered the First Name")
                .Length(2, 50).WithMessage("The Name must have between 2 and 150 characters");
        }
        protected void ValidateLastName()
        {
            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Please ensure you have entered the Last Name")
                .Length(2, 50).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateBirthDate()
        {
            RuleFor(c => c.BirthDate)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("The customer must have 18 years or more");
        }

        protected void ValidateGrossSalary()
        {
            RuleFor(c => c.GrossSalary)
                .NotEmpty();
        }

        protected void ValidateNetSalary()
        {
            RuleFor(c => c.NetSalary)
                .NotEmpty();
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(0);
        }

        protected void ValidateUserTypeId()
        {
            RuleFor(c => c.UserTypeId)
                .NotEqual(0);
        }

        protected static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }
    }
}