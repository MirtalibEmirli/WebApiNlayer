using Application.CQRS.Customers.Queries.Requests;
using Application.CQRS.Customers.Queries.Responses;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Customers.Handlers.QueryHandlers;

public sealed class GetAllCustomersHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<GetAllCustomersRequest, ResponseModelPagination<GetAllCustomersResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ResponseModelPagination<GetAllCustomersResponse>> Handle(GetAllCustomersRequest request, CancellationToken cancellationToken)
    {
        var customers = _unitOfWork.CustomerRepository.GetAll();
        var totalCount= customers.Count();
        
         customers = customers.Skip((request.Page-1)*request.Limit ).Take(request.Limit);   

        var mappedItems = new List<GetAllCustomersResponse>();
        foreach (var item in customers)
        {
            var data = new GetAllCustomersResponse()
            {
                CreatedDate =item.CreatedDate,
                FirstName = item.FirstName, 
                LastName = item.LastName,
                Id = item.Id,
                Balance = item.Balance, 
                Bill= item.Bill,
                Email= item.Email,  
            };
            mappedItems.Add(data);  
        }
        var responseModel = new Pagination<GetAllCustomersResponse>()
        {
            Items = mappedItems,
            TotalCount = totalCount,
        };

        return   new ResponseModelPagination<GetAllCustomersResponse> 
        {
            Data = responseModel,
            IsSuccess = true
        };
    }
}
