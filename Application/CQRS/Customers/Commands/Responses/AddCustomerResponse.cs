namespace Application.CQRS.Customers.Commands.Responses;

public sealed class AddCustomerResponse
{
    public  string FirstName { get; set; }
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
}
