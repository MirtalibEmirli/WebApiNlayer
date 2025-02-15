using Common.GlobalResponses.Generics;
using Domain.Entities;
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
    {
        
        {
            };
        {
            Id = request.Id,
            Name = product.Name,
            CreatedDate = product.CreatedDate,

        {
        };
        
    }
}
