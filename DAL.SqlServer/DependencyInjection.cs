using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SqlServer;

public static class DependencyInjection
{

    public static IServiceCollection AddSqlServerServices(this IServiceCollection services, string connectionString)
    {
        services.AddSqlServerServices(connectionString);
        return   services;
    }

}
