using Application.CQRS.Customers.Commands.Requests;
using Application.CQRS.Customers.Commands.Responses;
using Common.Exceptions;
using Common.GlobalResponses.Generics;
using Domain.Entities;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Customers.Handlers.CommandHandlers;

public class UpdateCustomerHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateCustomerRequest, ResponseModel<UpdateCustomerResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ResponseModel<UpdateCustomerResponse>> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        if (request == null || request.Id == 0) throw new BadRequestException("Request is null or Customer ID is missing. ");

        var checkCustomer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);
        if (checkCustomer == null) throw new NotFoundException(typeof(Customer), request.Id);

        var customerToUpdate = new Customer
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Balance = request.Balance,
            Bill = request.Bill,
            Email = request.Email,
            UpdatedBy = request.UpdatedBy,

        };
        int affectedRows = await _unitOfWork.CustomerRepository.UpdateAsync(customerToUpdate);

        if (affectedRows == 0) throw new UpdateFailedException($"Customer with ID {request.Id} could not be updated.");
        var updated = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);

        return new ResponseModel<UpdateCustomerResponse>()
        {
            Data = new UpdateCustomerResponse() { FirstName = updated.FirstName, LastName = updated.LastName, Id = updated.Id },
            IsSuccess = true
        };
    }
}
