using Application.CQRS.Products.Queries.Requests;
using Application.CQRS.Products.Queries.Responses;
using Common.GlobalResponses.Generics;
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
        if (product == null) return new ResponseModel<GetProductByIdResponse>
        {
            Data = null,
            IsSuccess = false,
            Errors = [@$"There is problem with fetching product , check the id .Ther eis no product in {request.Id}"]
        };
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
