using Domain.Entities;
using Repository.Repositories;
using DAL.SqlServer.Context;
using Dapper;

namespace DAL.SqlServer.Infrastructure;

public class SqlCustomerRepository : BaseSqlRepository, ICustomerRepository
{
    private readonly AppDbContext _context;
    public SqlCustomerRepository(string connectionString, AppDbContext appContext) : base(connectionString)
    {
        _context = appContext;
    }

    public async Task AddAsync(Customer customer)
    {
        using var conn = OpenConnection();
        var sql = @"INSERT INTO Customers([FirstName],[LastName],[Email]) VALUES(@FirstName,@LastName ,@Email);SELECT SCOPE_IDENTITY()";
        var generatedID = await conn.ExecuteScalarAsync<int>(sql, customer);
        customer.Id = generatedID;
    }

    public Task<bool> DeleteAsync(int id, int deletedBy)
    {
        throw new NotImplementedException();
    }


    public IQueryable<Customer> GetAll()
    {
        var sql = "SELECT * FROM Customers";
        using var conn = OpenConnection();
        return conn.Query<Customer>(sql).AsQueryable();
    }

    public Task<IEnumerable<Customer>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        var sql = @"SELECT c.*
                    From Customers c
                    WHERE c.Id=@Id AND c.IsDeleted=0;";
        //https://www.learndapper.com/saving-data/insert
        using var connection = OpenConnection();
        return await connection.QueryFirstOrDefaultAsync<Customer>(sql, new { Id = id });

    }

    public async Task<IEnumerable<Customer>> GetByKey(string key)
    {
        var sql = @"SELECT c.*
                    FROM Customers c
                    WHERE c.[Name] LIKE '%' + @Key + '%' AND c.IsDeleted=0";
        using var conn = OpenConnection();
        return await conn.QueryFirstOrDefaultAsync(sql, new { Key = key });

    }

    public Task UpdateAsync(Customer customer)
    {
        throw new NotImplementedException();
    }
}


