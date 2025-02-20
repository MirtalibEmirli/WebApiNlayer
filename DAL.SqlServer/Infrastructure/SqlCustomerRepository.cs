using Common.Exceptions;
using DAL.SqlServer.Context;
using Dapper;
using Domain.Entities;
using Repository.Repositories;

namespace DAL.SqlServer.Infrastructure;

public class SqlCustomerRepository : BaseSqlRepository, ICustomerRepository
{
    private readonly AppDbContext _context;
    public SqlCustomerRepository(string connectionString, AppDbContext appContext) : base(connectionString)
    {
        _context = appContext;
    }

    public Exception UpdateFailedException { get; private set; }

    public async Task AddAsync(Customer customer)
    {
        using var conn = OpenConnection();
        var sql = @"INSERT INTO Customers([FirstName],[LastName],[Email]) VALUES(@FirstName,@LastName ,@Email);SELECT SCOPE_IDENTITY()";
        var generatedID = await conn.ExecuteScalarAsync<int>(sql, customer);
        customer.Id = generatedID;
    }

    public async Task<bool> DeleteAsync(int Id, int deletedBy)
    {
        var checkSql = "Select Id From Customers Where Id=@id AND IsDeleted=0";
        var sql = @"UPDATE Customers
                    SET IsDeleted=1,
                    DeletedBy =@deletedBy,
                    DeletedDate =GETDATE()
                    WHERE Id =@id";
        using var connection = OpenConnection();
        using var transaction = connection.BeginTransaction();
        var customerId = await connection.ExecuteScalarAsync<int?>(checkSql, new { Id }, transaction);
        if (!customerId.HasValue)
            return false;

        var affectedRow = await connection.ExecuteAsync(sql, new { Id, deletedBy }, transaction);
        transaction.Commit();
        return affectedRow > 0;
    }


    public IQueryable<Customer> GetAll()
    {
        var sql = "SELECT * FROM Customers";
        using var conn = OpenConnection();
        return conn.Query<Customer>(sql).AsQueryable();
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        var sql = "Select * FROM Customers";
        using var conn = OpenConnection();
        return await conn.QueryAsync<Customer>(sql);

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
                    WHERE c.[FirstName] LIKE '%' + @Key + '%' AND c.IsDeleted=0";
        using var conn = OpenConnection();
        return await conn.QueryAsync<Customer>(sql, new { Key = key });

    }

    public async Task<int> UpdateAsync(Customer customer)
    {
        var sql = @"UPDATE Customers 
                    Set FirstName = @FirstName,
                    LastName = @LastName,
                    Email=@Email,
                    UpdatedBy =@UpdatedBy,
                    UpdatedDate  =@UpdatedDate,
                    Balance=@Balance,
                    Bill=@Bill
                    WHERE Id=@Id";
        using var conn = OpenConnection();
        using var transaction = conn.BeginTransaction();

        try
        {
            customer.UpdatedDate = DateTime.UtcNow;//daha suretlidir database terefde yazmaqdansa
            var affectedRows = await conn.ExecuteAsync(sql, customer, transaction);
            if (affectedRows == 0)
            {
                transaction.Rollback();
                return 0;
            }
            transaction.Commit();
            return affectedRows;
        }
        catch (Exception error)
        {
            transaction.Rollback();

            throw new UpdateFailedException("The Update Failed in the Dapper side ");
        }


    }
}


//var emailCheckSql = "SELECT COUNT(*) FROM Customers WHERE Email = @Email AND Id <> @Id";
//    var existingEmails = await conn.ExecuteScalarAsync<int>(emailCheckSql, new { customer.Email, customer.Id }, transaction);
//if (existingEmails > 0)
//{
//    throw new DatabaseException($"Email {customer.Email} is already in use.");
//}
