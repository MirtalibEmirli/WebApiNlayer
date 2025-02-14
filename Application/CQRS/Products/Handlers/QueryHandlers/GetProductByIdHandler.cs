using Application.CQRS.Products.Queries.Request;
using Application.CQRS.Products.Queries.Response;
using Common.GlobalResponses.Generics;
using Domain.Entities;
using MediatR;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Products.Handlers.QueryHandlers;

public class GetProductByIdHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<GetProductByIdRequest, ResponseModel<GetProductByIdResponse>>
{
    private readonly IUnitOfWork _unitOfWork=unitOfWork;
    public async Task<ResponseModel<GetProductByIdResponse>> 
        Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        

        Product product = await _unitOfWork.ProductRepository.GetById(request.Id);
        if (product==null)
        {
            return new ResponseModel<GetProductByIdResponse>
            {Data = null,
                Errors = ["The Product does not exist with provided it"]

            };
        }
        var getByIdResponse = new GetProductByIdResponse
        {
            CreatedDate = product.CreatedDate,
            Id = product.Id,
            Name = product.Name

        };
        return  new ResponseModel<GetProductByIdResponse>
        {
            Data = getByIdResponse,
            IsSuccess=true

        };
        
    }
}
