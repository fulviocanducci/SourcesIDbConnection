using Data;
using Repositories.Base;
using System.Data;
namespace Repositories
{
   public abstract class PeopleRepositoryAbstract : RepositoryAbstract<People, ulong>
   {
      protected PeopleRepositoryAbstract(IDbConnection connection) : base(connection)
      {
      }
   }
}
