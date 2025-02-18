using Application.CQRS.Customers.Queries.Responses;
using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Customers.Queries.Requests;

public  sealed class GetCustomerByKeyRequest:IRequest<ResponseModel<GetCustomerByKeyResponse>>
{
    public string Key { get; set; }

}
