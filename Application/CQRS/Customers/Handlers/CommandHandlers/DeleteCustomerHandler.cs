using Application.CQRS.Customers.Commands.Requests;
using Application.CQRS.Customers.Commands.Responses;
using Common.Exceptions;
using Common.GlobalResponses.Generics;
using Domain.Entities;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Customers.Handlers.CommandHandlers;

public class DeleteCustomerHandler(IUnitOfWork unitOfWork) : 
IRequestHandler<DeleteCustomerRequest, ResponseModel<DeleteCustomerResponse>>
{
    private readonly IUnitOfWork _unitOfWork =unitOfWork;
    public async Task<ResponseModel<DeleteCustomerResponse>> 
    Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
    {

      var isDeleted= await _unitOfWork.CustomerRepository.DeleteAsync(request.Id,1);
        if (!isDeleted)
            throw new DeleteFailedException($"Delete is failed .The id is null or there is no Customer with {request.Id} id in the database");

        return new ResponseModel<DeleteCustomerResponse>()
        {
            Data=new DeleteCustomerResponse() { Id=request.Id}
            ,IsSuccess=isDeleted    
        };
    }
}



