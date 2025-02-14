using Application.CQRS.Products.Commands.Responses;
using Application.CQRS.Products.Queries.Response;
using Common.GlobalResponses.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Products.Queries.Request;

public sealed class GetAllProductsRequest:IRequest<ResponseModelPagination<GetAllProductsResponse>>
{
    public int Limit { get; set; } = 10;
    public int Page { get; set; } = 1;
}
