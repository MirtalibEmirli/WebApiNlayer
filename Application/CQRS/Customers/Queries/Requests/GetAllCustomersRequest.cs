using Application.CQRS.Customers.Queries.Responses;
using Common.GlobalResponses.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Customers.Queries.Requests;

public sealed class GetAllCustomersRequest:IRequest<ResponseModelPagination<GetAllCustomersResponse>>
{
    public int Limit { get; set; }
    public int Page { get; set; }

}
