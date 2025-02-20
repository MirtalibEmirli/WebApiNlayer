using DAL.SqlServer.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;

namespace DAL.SqlServer.Infrastructure;

public class SqlUserRepository(AppDbContext appDbContext) : IUserRepository
{
    
    private readonly AppDbContext _context=appDbContext;
    public IQueryable<User> GetAll()
    {
      return  _context.Users.OrderByDescending(u=>u.CreatedDate).Where(u=>u.IsDeleted==false);      
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await _context.Users.Where(u=>u.IsDeleted == false).FirstOrDefaultAsync(u=>u.Email == email);  
    }

    public async Task<User> GetByIdAsync(int id)
    {
       return await _context.Users.FirstOrDefaultAsync(u=>u.Id == id);    
    }

    public async Task RegisterUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(int id)
    {
        var current = await _context.Users.FirstOrDefaultAsync( u=>u.Id == id);
        current.IsDeleted = true;
        current.DeletedDate = DateTime.Now;
        current.DeletedBy = 1;

    }

    public void UpdateUser(User user)
    {
        user.UpdatedDate=DateTime.Now;
        _context.Update(user);  
    }
}
