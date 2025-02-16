namespace Application.CQRS.Products.Queries.Responses;

public sealed class GetProductByIdResponse
{ 
    public string Name { get; set; }
    public DateTime CreatedDate{ get; set; }
    public int Id { get; set; }
} 

