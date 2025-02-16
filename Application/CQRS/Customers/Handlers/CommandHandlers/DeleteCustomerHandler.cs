using Application.CQRS.Customers.Commands.Requests;
using Application.CQRS.Customers.Commands.Responses;
using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Customers.Handlers.CommandHandlers;

public class DeleteCustomerHandler : 
IRequestHandler<DeleteCustomerRequest, ResponseModel<DeleteCustomerResponse>>
{
    public Task<ResponseModel<DeleteCustomerResponse>> 
    Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}



