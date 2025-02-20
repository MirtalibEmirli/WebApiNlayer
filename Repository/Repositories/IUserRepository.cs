using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories;

public interface IUserRepository
{
    public Task RegisterUser(User user);
    void UpdateUser(User user);
    IQueryable<User> GetAll();
    Task<User> GetByIdAsync(int id);
    Task<User> GetByEmailAsync(string email);
    Task Remove(int id);
}
