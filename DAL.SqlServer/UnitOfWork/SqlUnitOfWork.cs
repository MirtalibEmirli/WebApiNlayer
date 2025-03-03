using DAL.SqlServer.Context;
using DAL.SqlServer.Infrastructure;
using Repository.Common;
using Repository.Repositories;

namespace DAL.SqlServer.UnitOfWork;

public class SqlUnitOfWork(string connection ,AppDbContext context) : IUnitOfWork
{
    private readonly string _connectionString = connection;
    private readonly AppDbContext _context = context; 

    public SqlProductRepository productRepository;

    public IProductRepository ProductRepository => productRepository??new SqlProductRepository(_connectionString,_context);

    public SqlCustomerRepository customerRepository;
    public ICustomerRepository CustomerRepository => customerRepository ?? new SqlCustomerRepository(_connectionString,_context);

    public SqlUserRepository userRepository;    
    public IUserRepository UserRepository => userRepository??new SqlUserRepository(_context);

    public SqlTableRepository tableRepository;
    public ITableRepository TableRepository => tableRepository??new SqlTableRepository(_connectionString, _context);

    public async Task<int> SaveChanges()
    {
        return await _context.SaveChangesAsync();
    }
}
