using DAL.SqlServer.Context;
using Dapper;
using Domain.Entities;

using Repository.Repositories;

namespace DAL.SqlServer.Infrastructure;

public class SqlTableRepository(string conn, AppDbContext appDbContext) : BaseSqlRepository(conn), ITableRepository
{

    private readonly AppDbContext _context = appDbContext;
  
    public async Task CreateTable(Table table)
    {
        using var connection = OpenConnection();

        var sql = @"INSERT INTO Tables( [TableNumber],[Capacity], [CreatedBy]) VALUES(@TableNumber,@Capacity,@CreatedBy); SELECT SCOPE_IDENTITY()";
        table.CreatedBy = 1;
        var genereatedId = await connection.ExecuteScalarAsync<int>(sql, table);
        table.Id = genereatedId;
        //var a = await _context.AddAsync(table);
    }

   

    public async Task<IQueryable<Table>> GetAllTables()
    {
        var sql = "SELECT t.* FROM Tables t WHERE t.IsDeleted=0";
        using var connection = OpenConnection();
        return (await connection.QueryAsync<Table>(sql)).AsQueryable();

        //return _context.Tables.Where(t => t.IsDeleted == false).OrderByDescending(t => t.CreatedDate);
    }

    public async Task<IEnumerable<Table>> GetByKey(string key)
    {
        var sql = @" SELECT t.*    
                     From Tables t
                     WHERE t.[TableNumber] LIKE '%' + @Key + '%'
                     AND
                     t.[IsDeleted]=0";

        using var conn = OpenConnection();  

        return  (await conn.QueryAsync<Table>(sql, new {Key= key }));
       
        //return _context.Tables.Where(t => t.TableNumber.Contains(key)).AsQueryable();


    }


    public   Task<Table> GetTableById(int id)
    {
        var sql = @"SELECT c.* 
                    FROM Tables c
                    WHERE c.[Id] =@id AND c.[IsDeleted]=0";
        using var connection = OpenConnection();
        return     connection.QueryFirstOrDefaultAsync<Table>(sql, new {Id=id});
    }

    public async Task UpdateTable(Table table)
    {
         _context.Update(table); 
    }

    public Task<bool> DeleteTable(int deletedBy, int Id)
    {



        //var checkSql = "SELECT Id FROM Products WHERE Id =@id AND IsDeleted=0";

        //var sql = @"    UPDATE Products
        //                Set IsDeleted=1,
        //                DeletedBy=@deletedBy,
        //                DeletedDate=GETDATE()
        //                Where Id =@id";

        //using var conn = OpenConnection();
        //using var transaction = conn.BeginTransaction();
        //var productId = await conn.ExecuteScalarAsync<int?>(checkSql, new { id }, transaction);
        //if (!productId.HasValue)
        //    return false;
        //var affectedRow = await conn.ExecuteAsync(sql, new { id, deletedBy }, transaction);
        //transaction.Commit();
        //return affectedRow > 0;
        throw new NotImplementedException();    
    }
}




