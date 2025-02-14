using Application.CQRS.Products.Queries.Request;
using Application.CQRS.Products.Queries.Response;
using Common.GlobalResponses.Generics;
using Domain.Entities;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Products.Handlers.QueryHandlers;


public class GetAllProductsHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllProductsRequest, ResponseModelPagination<GetAllProductsResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ResponseModelPagination<GetAllProductsResponse>> 
    Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {

        var products = _unitOfWork.ProductRepository.GetAll();
        if (!products.Any())
        {
               return new ResponseModelPagination<GetAllProductsResponse>()
            {
                Data = null,
                Errors = [],
                IsSuccess = true
            };
        }

        var totalCount = products.Count();
        products = products.Skip((request.Page - 1) * request.Limit).Take(request.Limit);
        var mappedProduct = new List<GetAllProductsResponse>();
    
        foreach (var item in products)
        {
            var mapped = new GetAllProductsResponse()
            {
                Name=item.Name,
                Id=item.Id,
                CreatedTime=item.CreatedDate,
                UpdatedTime=item.UpdatedDate,
                DeletedTime=item.DeletedDate
            };
            mappedProduct.Add(mapped);
        }

        var response = new Pagination<GetAllProductsResponse>()
        {
            Data=mappedProduct,
            TotalDataCount = totalCount
        };

        return   new ResponseModelPagination<GetAllProductsResponse>()
        {
            Data = response,
            Errors = [],
            IsSuccess=true
        };

    }
}