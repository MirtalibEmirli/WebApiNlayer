using Application.CQRS.Customers.Queries.Responses;
using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Customers.Queries.Requests;

public sealed class GetCustomerByIdRequest:IRequest<ResponseModel<GetCustomerByIdResponse>>
{
    public int Id { get; set; }
}
