using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
namespace Repositories.Extensions
{
   public static class ConnectionRepositoryExtension
   {
      public static IServiceCollection AddConnectionRepository<T>(this IServiceCollection services, string connectionString) 
         where T: IDbConnection, new()
      {
         T connection = Activator.CreateInstance<T>();
         connection.ConnectionString = connectionString;
         services.AddScoped<IDbConnection>(_ => connection);
         return services;
      }
   }
}