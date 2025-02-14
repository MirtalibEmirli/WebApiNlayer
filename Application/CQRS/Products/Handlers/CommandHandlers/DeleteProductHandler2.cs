//using Application.CQRS.Products.Commands.Requests;
//using Application.CQRS.Products.Commands.Responses;
//using Common.GlobalResponses.Generics;
//using MediatR;
//using Repository.Common;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.CQRS.Products.Handlers.CommandHandlers;

//public class DeleteProductHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductRequest, ResponseModel
//    <DeleteProductResponse>>
//{
//    private readonly IUnitOfWork _unitOfWork= unitOfWork;   
//    public async Task<ResponseModel<DeleteProductResponse>>
//        Handle(DeleteProductRequest request, CancellationToken cancellationToken)
//    {

//        if (request == null||request.productId==0) 
//            return  new ResponseModel<DeleteProductResponse>{
//                Data=null,
//                IsSuccess=false,
//                Errors = ["The Request cant be nulll and check The productId , add correct id."] };
//        var isDeleted  = await _unitOfWork.ProductRepository.DeleteAsync(request.productId,request.deletedBy);


//        if (isDeleted)
//        {
//           var model = new DeleteProductResponse { isDeleted = true };  
//            return new ResponseModel<DeleteProductResponse> { Data = model, IsSuccess = true,Errors=null };
//        }

//        return new ResponseModel<DeleteProductResponse>
//        {
//            Data = null,
//            IsSuccess = false,
//            Errors=["There was error while was deleting the Product, please attempt again"]
//        };
//    }
//}
