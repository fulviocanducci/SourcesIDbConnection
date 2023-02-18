using System.Data;

namespace Repositories
{
   public class PeopleRepository : PeopleRepositoryAbstract
   {
      public PeopleRepository(IDbConnection connection) : base(connection)
      {
      }
   }
}
