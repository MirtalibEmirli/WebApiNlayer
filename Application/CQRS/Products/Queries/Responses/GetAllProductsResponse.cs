namespace Application.CQRS.Products.Queries.Responses;

public sealed class GetAllProductsResponse
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

}
