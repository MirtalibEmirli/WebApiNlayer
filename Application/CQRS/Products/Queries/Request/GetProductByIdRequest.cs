using Application.CQRS.Products.Queries.Response;
using Common.GlobalResponses.Generics;
using MediatR;
using System;
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace Application.CQRS.Products.Queries.Request;

public sealed class GetProductByIdRequest:IRequest<ResponseModel<GetProductByIdResponse>>
{
    public int Id { get; set; }
}
 





