using Domain.BaseEntities;

namespace Domain.Entities;

public class Customer: BaseEntity
{
    public   required  string LastName { get; set; }

    public required string FirstName { get; set; }

    
    public string? Email { get; set; }

    public int Balance { get; set; }

    public int Bill { get; set; }
}
