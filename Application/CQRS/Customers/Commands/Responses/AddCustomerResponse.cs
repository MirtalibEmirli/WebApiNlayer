namespace Application.CQRS.Customers.Commands.Responses;

public sealed class AddCustomerResponse
{
    public  string Name { get; set; }
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
}
