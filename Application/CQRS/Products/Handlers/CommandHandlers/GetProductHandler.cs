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

public class GetProductHandler (IUnitOfWork unitOfWork): IRequestHandler<GetProductRequest, ResponseModel<GetProductResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;   

    public async Task<ResponseModel<GetProductResponse>>
        Handle(GetProductRequest request, CancellationToken cancellationToken)
    {
        if (request.Id==0)
        {
            return   new ResponseModel<GetProductResponse> { Data = null
            ,
                Errors = ["Id is empty ,please Add Id for GetProduct"],
                IsSuccess = false,
            };   
            
        }
        var procutd = await _unitOfWork.ProductRepository.GetById(request.Id);
        var getProductResponse = new GetProductResponse
        {
            Id = request.Id,
            Name = procutd.Name,
        };



        return   new ResponseModel<GetProductResponse>()
        {
            IsSuccess = true,
            Errors=null,
            Data = getProductResponse   
        };

    }



}
