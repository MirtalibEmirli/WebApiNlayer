using System.ComponentModel.DataAnnotations;

namespace Application.CQRS.Customers.Queries.Responses;

public sealed class   GetAllCustomersResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string LastName { get; set; }

    public string FirstName { get; set; }

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    public int Balance { get; set; }

    public int Bill { get; set; }
}
