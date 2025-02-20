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
    public ICustomerRepository CustomerRepository { get; }
    public IUserRepository UserRepository { get; }   
    Task<int> SaveChanges();

}
