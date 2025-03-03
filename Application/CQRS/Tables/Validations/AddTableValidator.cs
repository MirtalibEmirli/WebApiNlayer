using FluentValidation;
using System.Data;

namespace Application.CQRS.Tables.Validations;

public class AddTableValidator:AbstractValidator<Handlers.AddTable.Command>
{
    public AddTableValidator()
    {
        RuleFor(x=>x.TableNumber).NotEmpty();   
    }
}
