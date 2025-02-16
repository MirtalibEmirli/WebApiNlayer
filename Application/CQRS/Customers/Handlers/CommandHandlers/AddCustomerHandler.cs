using Application.CQRS.Customers.Commands.Requests;
using Application.CQRS.Customers.Commands.Responses;
using Common.GlobalResponses.Generics;
using Domain.Entities;
using MediatR;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Customers.Handlers.CommandHandlers;

public sealed class AddCustomerHandler (IUnitOfWork unitOfWork): IRequestHandler<AddCustomerRequest,
ResponseModel<AddCustomerResponse>>
{
    private readonly IUnitOfWork _unitOfWork =unitOfWork;           
    public async Task<ResponseModel<AddCustomerResponse>> Handle(AddCustomerRequest request, CancellationToken cancellationToken)
    {
        if(request==null||string.IsNullOrWhiteSpace(request.FirstName)) return new ResponseModel<AddCustomerResponse>
        {
            Data = null,
            IsSuccess = false,
            Errors = ["Request is null","The CustomerName is null"]
        };

        var newCustomer = new Customer() {
            FirstName = request.FirstName, 
            LastName = request.LastName ,
            Email = request.Email , 
        };
        await _unitOfWork.CustomerRepository.AddAsync(newCustomer);
        var responseModel = new AddCustomerResponse()
        {
            Name=newCustomer.FirstName,
            CreatedDate =newCustomer.CreatedDate,
            Id = newCustomer.Id,    
            
        };

        return   new ResponseModel<AddCustomerResponse>
        {Data=responseModel,
        IsSuccess=true,
        };
    }
}
