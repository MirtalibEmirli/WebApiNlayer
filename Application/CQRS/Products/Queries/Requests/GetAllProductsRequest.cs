using Application.CQRS.Products.Queries.Responses;
using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Products.Queries.Requests;

public sealed class GetAllProductsRequest:IRequest<ResponseModelPagination<GetAllProductsResponse>>
{
    public int Limit { get; set; } = 5;
    public int Page { get; set; } = 1;
}
