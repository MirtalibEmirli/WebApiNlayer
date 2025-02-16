﻿using Application.CQRS.Customers.Commands.Responses;
using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Customers.Commands.Requests;
 
public record struct DeleteCustomerRequest:IRequest<ResponseModel<DeleteCustomerResponse>>
{
    public int Id { get; set; }
}
