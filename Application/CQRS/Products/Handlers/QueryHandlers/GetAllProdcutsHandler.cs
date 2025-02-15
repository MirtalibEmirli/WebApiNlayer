
using Application.CQRS.Products.Queries.Requests;
using Application.CQRS.Products.Queries.Responses;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Products.Handlers.QueryHandlers;

public class GetAllProdcutsHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<GetAllProductsRequest, ResponseModelPagination<GetAllProductsResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ResponseModelPagination<GetAllProductsResponse>>
      Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {
        //var products = _unitOfWork.ProductRepository.GetAll();
        //if (!products.Any())
        //    return new ResponseModelPagination<GetAllProductsResponse>
        //{
        //    Data = null,
        //    Errors = ["There is no product  in the DataBase"],
        //    IsSuccess = false
        //};

        //var page = request.Page;
        //var limit = request.Limit;
        //var totalCount = products.Count();
        //var productsToResponse = products.Skip((page - 1) * limit).Take(limit);

        //var mappedProducts = new List<GetAllProductsResponse>();
        //foreach (var product in productsToResponse)
        //{
        //    var mapped = new GetAllProductsResponse
        //    {
        //        CreatedTime = product.CreatedDate,
        //        Name = product.Name,    
        //        Id = product.Id,    
        //        UpdatedTime = product.UpdatedDate,  
        //    };
        //    mappedProducts.Add(mapped); 
        //}
        //var response = new Pagination<GetAllProductsResponse>() { Items=mappedProducts,TotalCount=totalCount};

        //return new ResponseModelPagination<GetAllProductsResponse>
        //{
        //    Data = response,
        //    IsSuccess = true,
        //    Errors = []

        //};

        //getall from DataBase
        var products = _unitOfWork.ProductRepository.GetAll();

        ///checked it 
        if (products == null) return new ResponseModelPagination<GetAllProductsResponse>()
        {
            Data = null,
            IsSuccess = false,
            Errors = ["There is no product in The Database"]
        };

        var page = request.Page;
        var limit = request.Limit;

        var totalCount = products.Count();
        //product for mapp get for the page
        var productToMapp = products.Skip((page - 1) * limit).Take(limit);

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
