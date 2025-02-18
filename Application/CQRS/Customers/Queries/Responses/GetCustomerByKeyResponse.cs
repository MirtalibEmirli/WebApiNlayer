namespace Application.CQRS.Customers.Queries.Responses;

public sealed class GetCustomerByKeyResponse
{
    public int Id { get; set; }
    public string LastName { get; set; }

    public string FirstName { get; set; }


    public string? Email { get; set; }

    public int Balance { get; set; }

    public int Bill { get; set; }

}

