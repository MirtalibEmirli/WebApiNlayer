using Application.CQRS.Customers.Queries.Responses;
using Common.GlobalResponses;
using Common.GlobalResponses.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Customers.Queries.Requests;

public sealed class GetCustomerByIdRequest:IRequest<ResponseModel<GetCustomerByIdResponse>>
{
    public int Id { get; set; }
}
