using DemoApi.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApi.Logic.Validators
{
    public class CustomerCreateValidator : AbstractValidator<CustomerCreate>
    {
        public CustomerCreateValidator()
        {
            RuleFor(x => x.FirstName).NotNull().Length(1, 40);
            RuleFor(x => x.LastName).NotNull().Length(1, 40);
            RuleFor(x => x.City).NotNull().Length(1, 40);
            RuleFor(x => x.Country).NotNull().Length(1, 40);
            RuleFor(x => x.Phone).NotNull().Length(9, 20);
        }
    }
}