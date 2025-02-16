using Application.CQRS.Customers.Commands.Responses;
using Common.GlobalResponses;
using Common.GlobalResponses.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Customers.Commands.Requests;


public sealed class AddCustomerRequest:IRequest<ResponseModel<AddCustomerResponse>>
{
    public required string LastName { get; set; }

    public required string FirstName { get; set; }
    public string? Email { get; set; }
}
