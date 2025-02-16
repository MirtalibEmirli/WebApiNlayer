
using Application.CQRS.Products.Commands.Requests;
using Application.CQRS.Products.Commands.Responses;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Products.Handlers.CommandHandlers;

public sealed class DeleteProductHandler(IUnitOfWork unitOfWork) : 
    IRequestHandler<DeleteProductRequest, ResponseModel<DeleteProductResponse>>
{   
    
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ResponseModel<DeleteProductResponse>> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.ProductRepository.DeleteAsync(request.Id,0);
        return new ResponseModel<DeleteProductResponse>
        {
            Data = new DeleteProductResponse { Message = "Deleted Successfully! " },
            Errors = null,
            IsSuccess = true
        };
    
    }
}
