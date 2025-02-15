using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Products.Queries.Responses;

public  class GetProductByIdResponse
{ 
    public string Name { get; set; }
    public DateTime CreatedDate{ get; set; }
    public int Id { get; set; }
} 

