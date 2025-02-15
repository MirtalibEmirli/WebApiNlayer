using Application.CQRS.Products.Queries.Requests;
using Application.CQRS.Products.Queries.Responses;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.CQRS.Products.Handlers.QueryHandlers;

public class GetProductByIdHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<GetProductByIdRequest, ResponseModel<GetProductByIdResponse>>
{
    private readonly IUnitOfWork _unitOfWork =  unitOfWork;   
    public async Task<ResponseModel<GetProductByIdResponse>> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {

        var product =await _unitOfWork.ProductRepository.GetById(request.Id);
        if (product == null)
            return new ResponseModel<GetProductByIdResponse>
            {
                IsSuccess = false,
                Data = null,
                Errors = ["The Product Not Found in database"]
            };
        var getProductByIdResponse = new GetProductByIdResponse
        {
            Id = request.Id,
            Name = product.Name,
            CreatedDate = product.CreatedDate,
        };

        return new ResponseModel<GetProductByIdResponse>
        {
            Data = getProductByIdResponse,
            IsSuccess = true,   
        };

    }
}
