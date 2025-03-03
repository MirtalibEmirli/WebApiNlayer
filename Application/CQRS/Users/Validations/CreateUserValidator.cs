using FluentValidation;

namespace Application.CQRS.Users.Validations;

public class CreateUserValidator:AbstractValidator<Handlers.Register.Command>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3);    

        RuleFor(u=>u.Phone).NotEmpty().MinimumLength(9).Matches(@"^\+994(5[015]|7[07])\d{7}$").MaximumLength
            (20);

        RuleFor(u => u.Email).EmailAddress().NotEmpty();


        RuleFor(u => u.SurName).NotEmpty();

    }
}
