using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Customers.Queries.Responses;

public class GetCustomerByIdResponse
{
    public required string Name { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public int Balance { get; set; }
    public int Bill { get; set; }
}
