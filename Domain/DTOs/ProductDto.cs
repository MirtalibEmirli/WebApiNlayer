﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int UpdatedBy { get; set; }
        public string Name { get; set; }
    }
}
