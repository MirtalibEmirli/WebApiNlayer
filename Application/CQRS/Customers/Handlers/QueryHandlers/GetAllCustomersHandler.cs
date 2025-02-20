using Application.CQRS.Customers.Queries.Requests;
using Application.CQRS.Customers.Queries.Responses;
using AutoMapper;
using Common.Exceptions;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Customers.Handlers.QueryHandlers;

public sealed class GetAllCustomersHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetAllCustomersRequest, ResponseModelPagination<GetAllCustomersResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<ResponseModelPagination<GetAllCustomersResponse>> Handle(GetAllCustomersRequest request, CancellationToken cancellationToken)
    {
        if (request == null) throw new BadRequestException("The Request is null");

        var customers = _unitOfWork.CustomerRepository.GetAll();

        var totalCount = customers.Count();

        customers = customers.Skip((request.Page - 1) * request.Limit).Take(request.Limit);
        var mappedItems = new List<GetAllCustomersResponse>();

        foreach (var item in customers)
        {
            var data = _mapper.Map<GetAllCustomersResponse>(item);
            mappedItems.Add(data);
        }
        var responseModel = new Pagination<GetAllCustomersResponse>()
        {
            Items = mappedItems,
            TotalCount = totalCount,
        };

        return new ResponseModelPagination<GetAllCustomersResponse>
        {
            Data = responseModel,
            IsSuccess = true
        };
    }
}
