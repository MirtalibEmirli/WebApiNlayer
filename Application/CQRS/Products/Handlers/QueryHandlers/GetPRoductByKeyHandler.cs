using Application.CQRS.Products.Queries.Requests;
using Application.CQRS.Products.Queries.Responses;
using Common.Exceptions;
using Common.GlobalResponses;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Products.Handlers.QueryHandlers;

public sealed class GetProductByKeyRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetProductsByKeyRequest, ResponseModel<GetProductsByKeyResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ResponseModel<GetProductsByKeyResponse>>
        Handle(GetProductsByKeyRequest request, CancellationToken cancellationToken)
    {
        var products =await _unitOfWork.ProductRepository.GetByKey(request.Key);
        //var products =   _unitOfWork.ProductRepository.GetAll().Where(c=>c.Name.Contains(request.Key)).ToList();
        if (products == null) throw new BadRequestException("There is no product with this key");

        var responseModel = new GetProductsByKeyResponse();
        //automapper lazimdi
        foreach (var item in products)
        {
            responseModel.Datas.Add(new Dto { CreatedDate=item.CreatedDate,Name=item.Name,Id=item.Id});
        }


        return new ResponseModel<GetProductsByKeyResponse>
        {
            IsSuccess = true,   
            Data = responseModel
        };


         
    }
}
