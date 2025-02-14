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
    public List<T> Data { get; set; }
    public int TotalDataCount { get; set; }
    public Pagination(List<T> data ,int count,bool isSucces)
    {
        Data = data;
        TotalDataCount = count;

    }
    public Pagination()
    {
        Data = [];
        TotalDataCount = 0;
    }

}
