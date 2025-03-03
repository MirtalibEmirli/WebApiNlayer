using Domain.Entities;

namespace Repository.Repositories;

public interface ITableRepository
{

    Task CreateTable(Table table);
    Task<bool> DeleteTable(int tableId,int Id);
    Task UpdateTable(Table table);
    Task<IQueryable<Table>> GetAllTables();
    Task<Table> GetTableById(int id);
    Task<IEnumerable<Table>> GetByKey(string key);//bu row ve ya diger siralama mentiqine gore ola biler
}
