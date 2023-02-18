using Microsoft.Extensions.DependencyInjection;
namespace Repositories.Extensions
{
   public static class RepositoryExtension
   {
      public static IServiceCollection AddRepository(this IServiceCollection services)
      {
         services.AddScoped<PeopleRepositoryAbstract, PeopleRepository>();
         return services;
      }
   }
}
