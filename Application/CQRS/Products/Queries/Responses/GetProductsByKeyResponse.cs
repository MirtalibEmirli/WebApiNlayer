using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Products.Queries.Responses;

public sealed class GetProductsByKeyResponse
{

    public List<Dto> Datas { get; set; }=new List<Dto>();
    
}

public sealed class Dto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
}