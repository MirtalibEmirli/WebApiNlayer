using Application.CQRS.Customers.Commands.Responses;
using Common.GlobalResponses.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Customers.Commands.Requests;

public class UpdateCustomerRequest:IRequest<ResponseModel<UpdateCustomerResponse>> 
{

}
