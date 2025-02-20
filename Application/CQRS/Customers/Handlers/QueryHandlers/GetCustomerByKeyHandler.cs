using Application.CQRS.Customers.Queries.Requests;
using Application.CQRS.Customers.Queries.Responses;
using Common.Exceptions;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Customers.Handlers.QueryHandlers;

public class GetCustomerByKeyHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetCustomerByKeyRequest, ResponseModel<GetCustomerByKeyResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ResponseModel<GetCustomerByKeyResponse>> Handle(GetCustomerByKeyRequest request, CancellationToken cancellationToken)
    {

        if (request == null || string.IsNullOrEmpty(request.Key))
            throw new BadRequestException($"Rrequest is  null or {request.Key} is null .Please send Correct Request");
        
        var customersByKey = await _unitOfWork.CustomerRepository.GetByKey(request.Key);

        var responseModel = new GetCustomerByKeyResponse() { Customers = customersByKey.ToList() };

        return new ResponseModel<GetCustomerByKeyResponse>
        {
            Data = responseModel,
            Errors = null,
            IsSuccess = true,
        };


    }
}
