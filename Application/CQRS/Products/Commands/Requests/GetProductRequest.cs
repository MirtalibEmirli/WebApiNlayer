using Application.CQRS.Products.Commands.Responses;
using Common.GlobalResponses.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Products.Commands.Requests;

public class GetProductRequest:IRequest<ResponseModel<GetProductResponse>>
{
    public int   Id { get; set; }


}
