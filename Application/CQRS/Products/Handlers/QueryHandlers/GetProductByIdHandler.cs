using Application.CQRS.Products.Queries.Requests;
using Application.CQRS.Products.Queries.Responses;
 
using Common.GlobalResponses.Generics;
using Domain.Entities;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Products.Handlers.QueryHandlers;

public sealed class GetProductByIdHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<GetProductByIdRequest, ResponseModel<GetProductByIdResponse>>
{
    private readonly IUnitOfWork _unitOfWork =unitOfWork;
    public async Task<ResponseModel<GetProductByIdResponse>> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {

        var product = await _unitOfWork.ProductRepository.GetById(request.Id);
        if (product == null) throw new Common.Exceptions.NotFoundException(typeof(Product), request.Id);
        var responseModel = new GetProductByIdResponse()
        {
            Id = request.Id,
            Name = product.Name,
            CreatedDate = product.CreatedDate,

        };
        return new ResponseModel<GetProductByIdResponse>
        {
            Data = responseModel,
            IsSuccess = true
        };
    }
}
