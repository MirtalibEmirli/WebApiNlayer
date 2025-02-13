using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories;

public interface ICustomerRepository
{
    Task AddAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task<bool> DeleteAsync(int id,int deletedBy);  
    IQueryable<Customer> GetAll();
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<IEnumerable<Customer>> GetByKey(string key);
    Task<Customer> GetByIdAsync(int id);    
}
