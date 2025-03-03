using Application.CQRS.Customers.Commands.Requests;
using FluentValidation;

namespace Application.CQRS.Customers.Validations;

public class CreateCustomerValidator:AbstractValidator<AddCustomerRequest>
{
    public CreateCustomerValidator()
    {
            RuleFor(c=>c.FirstName).NotNull().NotEmpty().MaximumLength(10);
            RuleFor(c=>c.Email).NotEmpty().MaximumLength(20).EmailAddress();   
    }
}
