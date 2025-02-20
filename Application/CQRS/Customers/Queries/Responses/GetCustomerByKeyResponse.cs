using Domain.Entities;

namespace Application.CQRS.Customers.Queries.Responses;

public sealed class GetCustomerByKeyResponse
{
   public List<Customer> Customers { get; set; }    

}

