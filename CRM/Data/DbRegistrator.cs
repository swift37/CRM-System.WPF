﻿using CRM.DAL;
using CRM.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CRM.Data
{
    public static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) => services
            .AddDbContext<CRMDbContext>(options =>
            {
                var type = configuration["Type"];
                switch (type)
                {
                    case null: throw new InvalidOperationException("Database type not defined");
                    default: throw new InvalidOperationException("Database type defined incorrectly");

                    case "MSSQL":
                        options.UseSqlServer(configuration.GetConnectionString(type));
                        break;
                    case "SQLite":
                        options.UseSqlite(configuration.GetConnectionString(type));
                        break;
                    case "InMemory":
                        options.UseInMemoryDatabase("Librarian.db");
                        break;
                }
            })
            .AddTransient<DbInitializer>()
            .AddRepositoriesDb()
            ;
    }
}
