using Application.CQRS.Products.Commands.Requests;
using FluentValidation;

namespace Application.CQRS.Products.Validations;

public class CreateProductValidator:AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
            RuleFor(x => x.Name).NotEmpty()
            .MaximumLength(10);

    }
}
