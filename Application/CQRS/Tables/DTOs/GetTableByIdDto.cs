namespace Application.CQRS.Tables.DTOs;

public class GetTableByIdDto
{
    public int İd { get; set; }
    public int Capacity { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public required string TableNumber { get; set; }
    public bool IsReserved { get; set; }   
}
