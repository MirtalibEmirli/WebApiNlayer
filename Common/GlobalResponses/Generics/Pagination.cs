using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Common.GlobalResponses.Generics;

public class Pagination<T>
{
    public List<T> Items { get; set; }
    
    public int TotalCount { get; set; }
    public Pagination()
    {
    }

}
