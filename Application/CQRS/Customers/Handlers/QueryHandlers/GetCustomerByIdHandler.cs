using Application.CQRS.Customers.Queries.Requests;
using Application.CQRS.Customers.Queries.Responses;
using Common.Exceptions;
using Common.GlobalResponses.Generics;
using Domain.Entities;
using MediatR;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Customers.Handlers.QueryHandlers;

public class GetCustomerByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetCustomerByIdRequest,
ResponseModel<GetCustomerByIdResponse>>
{
    private readonly IUnitOfWork _unitOfWork =unitOfWork;   
    public async Task<ResponseModel<GetCustomerByIdResponse>> Handle(GetCustomerByIdRequest request, CancellationToken cancellationToken)
    {
        var customer =await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);
        if (request == null||request.Id==0||customer==null)
            throw new NotFoundException(typeof(Customer),request.Id);
            //return new ResponseModel<GetCustomerByIdResponse>()
            //{
            //    Data = null,
            //    Errors = ["The Customer not found","Request is null","Id is null please send the correct Id"],
            //    IsSuccess=false,
            //};
        var responseModel = new GetCustomerByIdResponse
        {
            Name = customer.FirstName,
            LastName = customer.LastName,
            Balance = customer.Balance,
            Email = customer.Email,
            Bill = customer.Bill,
        };

        return new ResponseModel<GetCustomerByIdResponse>()
        {
            Data=responseModel,
            IsSuccess=true, 
        };

    }
}
