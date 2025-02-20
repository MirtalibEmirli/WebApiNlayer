using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Customers.Commands.Responses;

public record struct DeleteCustomerResponse
{
    public int Id { get; set; }
}
