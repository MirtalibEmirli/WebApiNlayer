using Application.CQRS.Products.Queries.Responses;
using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Products.Queries.Requests;

public class GetProductByIdRequest:IRequest<ResponseModel<GetProductByIdResponse>>
{
    public int Id { get; set; }
}
