using Domain.BaseEntities;

namespace Domain.Entities;

public class Table:BaseEntity
{
    
    // Məsələn, "A1", "B2" kimi nomreler olduqu  ucun string yazdm
    public string TableNumber { get; set; } 

    public int Capacity { get; set; }   // Masada neçə nəfər otura bilər

    public bool IsReserved { get; set; } = false;
}
