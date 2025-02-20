using Application.CQRS.Customers.Commands.Responses;
using Common.GlobalResponses.Generics;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Customers.Commands.Requests;

public class UpdateCustomerRequest:IRequest<ResponseModel<UpdateCustomerResponse>> 
{
    public int Id { get; set; }
   
    public string LastName { get; set; }

    public string FirstName { get; set; }

    public string? Email { get; set; }

    public int Balance { get; set; }
    
    public int? UpdatedBy { get; set; }
    
    public int Bill { get; set; }

}
