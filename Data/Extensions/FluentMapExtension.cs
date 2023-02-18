using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Data.Mappings;
using Microsoft.Extensions.DependencyInjection;
namespace Data.Extensions
{
   public static class FluentMapExtension
   {
      public static IServiceCollection AddDapperFluentMap(this IServiceCollection service)
      {
         FluentMapper.Initialize(config =>
         {
            config.AddMap(new PeopleMapping());
            
            config.ForDommel();
         });
         return service;
      }
   }
}