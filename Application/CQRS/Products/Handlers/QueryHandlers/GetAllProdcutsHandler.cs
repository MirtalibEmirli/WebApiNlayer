
using Application.CQRS.Products.Queries.Requests;
using Application.CQRS.Products.Queries.Responses;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;
using System.Collections.Generic;

namespace Application.CQRS.Products.Handlers.QueryHandlers;

public sealed class GetAllProdcutsHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<GetAllProductsRequest, ResponseModelPagination<GetAllProductsResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ResponseModelPagination<GetAllProductsResponse>>
      Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {
        

        //getall from DataBase
        var products = _unitOfWork.ProductRepository.GetAll();

        ///checked it 
        if (products == null) return new ResponseModelPagination<GetAllProductsResponse>()
        {
            Data = null,
            IsSuccess = false,
            Errors = ["There is no product in The Database"]
        };

     
        var totalCount = products.Count();
        //product for mapp get for the page
        var productToMapp = products.Skip((request.Page - 1) * request.Limit).Take(request.Limit);

        //products to response
        var productsToResponse = new List<GetAllProductsResponse>();

        foreach (var item in productToMapp)
        {
            var responseItem = new GetAllProductsResponse()
            {
                Id = item.Id,
                Name = item.Name,
                CreatedTime = item.CreatedDate,
                UpdatedTime = item.UpdatedDate,
            };
            productsToResponse.Add(responseItem);
        }

        var responseData = new Pagination<GetAllProductsResponse>()
        {
            Items = productsToResponse,
            TotalCount = totalCount,
        };
        return new ResponseModelPagination<GetAllProductsResponse>()
        {
            Data = responseData,
            IsSuccess = true,
        }
        ;
    }
}
