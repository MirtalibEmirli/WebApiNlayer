using Application.CQRS.Customers.Queries.Requests;
using Application.CQRS.Customers.Queries.Responses;
using Common.GlobalResponses.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Customers.Handlers.QueryHandlers;

public class GetCustomerByKeyHandler : IRequestHandler<GetCustomerByKeyRequest, ResponseModel<GetCustomerByKeyResponse>>
{
    public Task<ResponseModel<GetCustomerByKeyResponse>> Handle(GetCustomerByKeyRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
