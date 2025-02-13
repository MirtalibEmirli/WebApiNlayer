using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Products.Commands.Responses;

public class DeleteProductResponse
{
    public bool isDeleted { get; set; }
}
