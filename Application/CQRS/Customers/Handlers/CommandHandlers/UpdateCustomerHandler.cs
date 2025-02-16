using Application.CQRS.Customers.Commands.Requests;
using Application.CQRS.Customers.Commands.Responses;
using Common.GlobalResponses.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Customers.Handlers.CommandHandlers;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerRequest, ResponseModel<UpdateCustomerResponse>>
{
    public Task<ResponseModel<UpdateCustomerResponse>> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
