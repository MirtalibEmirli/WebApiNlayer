using DAL.SqlServer.Context;
using Dapper;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;

namespace DAL.SqlServer.Infrastructure;

public class SqlProductRepository : BaseSqlRepository, IProductRepository
{
    private readonly AppDbContext _appDbContext;
    public SqlProductRepository(string conn, AppDbContext appDb) : base(conn)
    {
        _appDbContext = appDb;

    }

    public async Task AddAsync(Product product)
    {
        var sql = @"INSERT INTO Products([Name],[CreatedBy])
                        VALUES(@Name,@CreatedBy);SELECT SCOPE_IDENTITY()";

        using var conn = OpenConnection();
        var generatedID = await conn.ExecuteScalarAsync<int>(sql, product);
        product.Id = generatedID;
    }

    public async Task<bool> DeleteAsync(int id, int deletedBy)
    {
        var checkSql = "SELECT Id FROM Products WHERE Id =@id AND IsDeleted=0";

        var sql = @"    UPDATE Products
                        Set IsDeleted=1,
                        DeletedBy=@deletedBy,
                        DeletedDate=GETDATE()
                        Where Id =@id";

        using var conn = OpenConnection();
        using var transaction = conn.BeginTransaction();
        var productId = await conn.ExecuteScalarAsync<int?>(checkSql, new { id }, transaction);
        if (!productId.HasValue)
            return false;
        var affectedRow = await conn.ExecuteAsync(sql, new { id, deletedBy }, transaction);
        transaction.Commit();
        return affectedRow > 0;
    }

    public IQueryable<Product> GetAll()
    {
        //efcore
        return _appDbContext.Products.OrderByDescending(c => c.CreatedDate).Where(c => c.IsDeleted == false);
    }

    public async Task<Product> GetById(int productId)
    {

        var sql = @"SELECT c.*
                        From Products c
                        Where c.Id =@id AND c.IsDeleted=0";
        using var conn = OpenConnection();
        return await conn.QueryFirstOrDefaultAsync<Product>(sql, new { id = productId });
    }

    public async Task<IEnumerable<Product>> GetByKey(string key)
    {
        var sql = @"   Select p.*
                        From Products p            
                        Where p.[Name] LIKE '%' +@Key +'%' and p.IsDeleted=0";
        using var conn = OpenConnection();
        return await conn.QueryAsync<Product>(sql, new { Key = key });
    }

    public async Task UpdateAsync(ProductDto product)
    {
        var sql = @"UPDATE Products
                    Set Name=@Name,
                    UpdatedBy =@UpdatedBy,
                    UpdatedDate=GETDATE()
                    Where Id =@Id";
        using var conn = OpenConnection();
        await conn.QueryAsync<ProductDto>(sql, product);
    }
}
