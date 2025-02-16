using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Products.Commands.Responses;

//record struct a bax
  
public   record struct DeleteProductResponse
{  
    
    public string Message { get; set; }

}
