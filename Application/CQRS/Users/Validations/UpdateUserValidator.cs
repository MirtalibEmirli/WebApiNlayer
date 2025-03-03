using FluentValidation;

namespace Application.CQRS.Users.Validations;
using Application.CQRS.Users.Handlers;

public class UpdateUserValidator:AbstractValidator<Update.Command>
{
    public UpdateUserValidator()
    {
        RuleFor(u=> u.Name).NotEmpty(); 
    }
}
