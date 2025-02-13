using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SqlServer.Infrastructure;

public abstract class BaseSqlRepository
{
    private readonly string _connectionString;

    public BaseSqlRepository(string connectionString)
    {
        _connectionString = connectionString;                   
    }
    protected SqlConnection OpenConnection()
    {
        var conn = new SqlConnection( _connectionString );  
        conn.Open();
        return conn;
    }
}
