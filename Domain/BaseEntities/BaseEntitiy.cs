using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BaseEntities;

public abstract class BaseEntitiy
{
    public int Id { get; set; }
    public int? UpdatedOn { get; set; }
    public int CreatedBy { get; set; }
    public int? DeletedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
    public BaseEntitiy()
    {
        CreatedDate = DateTime.Now;
    }
}
