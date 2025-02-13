using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Products.Commands.Responses;

public class GetAllProductsResponse
{
    public List<Product> Products { get; set; }    
 }
