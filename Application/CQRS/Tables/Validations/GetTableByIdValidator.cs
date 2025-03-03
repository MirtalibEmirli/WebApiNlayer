


using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Tables.Validations;

public class GetTableByIdValidator:AbstractValidator<Handlers.GetTableById.Query
    >
{

    public GetTableByIdValidator()
    {
         RuleFor(x=>x.Id).NotEmpty();   
    }
}
