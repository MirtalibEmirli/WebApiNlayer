using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common;

public interface IUnitOfWork
{
    public IProductRepository ProductRepository { get; }
    Task<int> SaveChanges();

}
