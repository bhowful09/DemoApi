using DemoApi.Domain;
using FluentValidation;

namespace DemoApi.Logic.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.FirstName).NotNull().Length(1, 40);
            RuleFor(x => x.LastName).NotNull().Length(1, 40);
            RuleFor(x => x.City).NotNull().Length(1, 40);
            RuleFor(x => x.Country).NotNull().Length(1, 40);
            RuleFor(x => x.Phone).NotNull().Length(9, 20);
        }
    }
}