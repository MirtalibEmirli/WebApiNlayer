using Application.CQRS.Products.Commands.Requests;
using Application.CQRS.Products.Commands.Responses;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Products.Handlers.CommandHandlers;

public class GetAllProductsHandler(IUnitOfWork unitOfWork) :
     IRequestHandler<GetAllProductsRequest, ResponseModel<GetAllProductsResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ResponseModel<GetAllProductsResponse>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            return new ResponseModel<GetAllProductsResponse>
            {
                Data = null,
                Errors = ["Send correct GET request"],
                IsSuccess = false
            };
        }

        var Products = _unitOfWork.ProductRepository.GetAll().ToList();

        if (Products == null || Products.Count == 0) return new ResponseModel<GetAllProductsResponse>
        {
            Data = null,
            Errors = ["There is no Product in Database "],
            IsSuccess = false
        };
        var getAllResponse = new GetAllProductsResponse()
        {
            Products = Products,
        };

        return new ResponseModel<GetAllProductsResponse>
        {

            Data = getAllResponse,
            IsSuccess = true
        ,
            Errors = null
        };
    }


}
