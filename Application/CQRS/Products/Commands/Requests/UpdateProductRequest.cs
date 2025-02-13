using Application.CQRS.Products.Commands.Responses;
using Common.GlobalResponses.Generics;
using Domain.DTOs;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Products.Commands.Requests;

public class UpdateProductRequest:IRequest<ResponseModel<UpdateProductResponse>>
{
    public ProductDto Product { get; set; }    


}
