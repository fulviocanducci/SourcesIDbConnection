using Dapper.FluentMap.Dommel.Mapping;
namespace Data.Mappings
{
   public class PeopleMapping : DommelEntityMap<People>
   {
      public PeopleMapping()
      {
         ToTable("peoples");
         Map(c => c.Id).ToColumn("id").IsIdentity().IsKey();
         Map(c => c.Name).ToColumn("name");
      }
   }
}
