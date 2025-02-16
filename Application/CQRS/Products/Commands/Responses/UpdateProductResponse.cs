using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Products.Commands.Responses;

public sealed class UpdateProductResponse
{
    public bool Success { get; set; }   
}
