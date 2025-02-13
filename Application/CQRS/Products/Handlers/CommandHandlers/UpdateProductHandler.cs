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

public class UpdateProductHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<UpdateProductRequest, ResponseModel<UpdateProductResponse>>
{
    private readonly IUnitOfWork _unitOfWork= unitOfWork;
    public async Task<ResponseModel<UpdateProductResponse>> 
        Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        if (request.Product == null)
            return new ResponseModel<UpdateProductResponse>   
            {
                Data = new UpdateProductResponse { Success = false },
                
                Errors = ["the product is null "],
                IsSuccess = false,
            };

        await _unitOfWork.ProductRepository.UpdateAsync(request.Product);

        var model = new UpdateProductResponse() { Success=true};
        return new ResponseModel<UpdateProductResponse>
        {
            Data = model,
            Errors = null,
            IsSuccess = true,
        };
    }
}
