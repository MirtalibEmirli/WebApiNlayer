using Application.CQRS.Customers.Commands.Requests;
using Application.CQRS.Customers.Commands.Responses;
using AutoMapper;
using Common.Exceptions;
using Common.GlobalResponses.Generics;
using Domain.Entities;
using MediatR;
using Repository.Common;
namespace Application.CQRS.Customers.Handlers.CommandHandlers;

public sealed class AddCustomerHandler(IUnitOfWork unitOfWork,IMapper mapper) : IRequestHandler<AddCustomerRequest,
ResponseModel<AddCustomerResponse>>
{
    private readonly IMapper _mapper=mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ResponseModel<AddCustomerResponse>> Handle(AddCustomerRequest request, CancellationToken cancellationToken)
    {

        if (request == null || string.IsNullOrWhiteSpace(request.FirstName))
            throw new BadRequestException("Request is invalid. FirstName is required.");

        //old
        //    return new ResponseModel<AddCustomerResponse>
        //{
        //    Data = null,
        //    IsSuccess = false,
        //    Errors = ["Request is not in the correct form and,The CustomerName is null"]
        //};

        var newCustomer = new Customer()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
        };
        await _unitOfWork.CustomerRepository.AddAsync(newCustomer);
        var responseModel =_mapper.Map<AddCustomerResponse>(newCustomer);
           

        return new ResponseModel<AddCustomerResponse>
        {
            Data = responseModel,
            IsSuccess = true,
        };
    }
}
