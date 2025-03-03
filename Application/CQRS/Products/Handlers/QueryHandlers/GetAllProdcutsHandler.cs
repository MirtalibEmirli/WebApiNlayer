
using Application.CQRS.Products.Queries.Requests;
using Application.CQRS.Products.Queries.Responses;
using AutoMapper;
using Common.Exceptions;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;
using System.Collections.Generic;

namespace Application.CQRS.Products.Handlers.QueryHandlers;

public sealed class GetAllProdcutsHandler(IUnitOfWork unitOfWork,IMapper mapper) :
    IRequestHandler<GetAllProductsRequest, ResponseModelPagination<GetAllProductsResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    public async Task<ResponseModelPagination<GetAllProductsResponse>>
      Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {
        

        //getall from DataBase
        var products = _unitOfWork.ProductRepository.GetAll();

        ///checked it 
        if (products == null) throw new BadRequestException("There is no product in The Database");

     
        var totalCount = products.Count();

        //product for mapp get for the page
        var productToMapp = products.Skip((request.Page - 1) * request.Limit).Take(request.Limit);

        //products to response
        var productsToResponse = new List<GetAllProductsResponse>();


        foreach (var item in productToMapp)
        {
            var responseItem = _mapper.Map<GetAllProductsResponse>(item);   
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
