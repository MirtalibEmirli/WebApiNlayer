using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task UpdateAsync(ProductDto product);  
    Task<bool> DeleteAsync(int productId,int deletedBy);
    IQueryable<Product> GetAll();   
    Task<Product> GetById(int productId);
    Task<IEnumerable<Product>> GetByKey(string key);

}
