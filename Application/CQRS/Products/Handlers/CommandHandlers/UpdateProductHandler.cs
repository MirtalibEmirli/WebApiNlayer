﻿using Application.CQRS.Products.Commands.Requests;
using Application.CQRS.Products.Commands.Responses;
using Common.Exceptions;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Products.Handlers.CommandHandlers;

public sealed class UpdateProductHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<UpdateProductRequest, ResponseModel<UpdateProductResponse>>
{
    private readonly IUnitOfWork _unitOfWork= unitOfWork;
    public async Task<ResponseModel<UpdateProductResponse>> 
        Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        if (request.Product == null ||request.Product.Id==0)
            throw new BadRequestException("The Request is not correct form .");
            //return new ResponseModel<UpdateProductResponse>   
            //{
            //    Data = new UpdateProductResponse { Success = false },
                
            //    Errors = ["the product is null "],
            //    IsSuccess = false,
            //};

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
