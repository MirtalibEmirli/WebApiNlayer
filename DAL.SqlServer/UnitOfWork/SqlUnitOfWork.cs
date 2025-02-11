using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SqlServer.UnitOfWork;


public class SqlUnitOfWork(string connectionString, AppDbContext context) : IUnitOfWork
{
    private readonly string _connectionString = connectionString;
    private readonly AppDbContext _context = context;
    public SqlCategoryRepository _sqlCategoryRepository;

    public IcategoryRepository CategoryRepository => _sqlCategoryRepository ?? new SqlCategoryRepository(_connectionString, _context);

    public Task<int> SaveChanges()
    {
        throw new NotImplementedException();

    }
}