using Application.CQRS.Products.Queries.Responses;
using Common.GlobalResponses;
using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Products.Queries.Requests;

public sealed class GetProductsByKeyRequest:IRequest<ResponseModel<GetProductsByKeyResponse>>
{
    public string Key { get; set; }
}
