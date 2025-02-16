using Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Customer: BaseEntity
{
    public     string LastName { get; set; }

    public   string FirstName { get; set; }

    
    public string? Email { get; set; }

    public int Balance { get; set; }

    public int Bill { get; set; }
}
