using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Base
{
   public interface IRepository<T, TKey>
   {
      TKey Insert(T model);
      Task<TKey> InsertAsync(T model);

      bool Update(T model);
      Task<bool> UpdateAsync(T model);

      T FirstOrDefault(TKey id);
      Task<T> FirstOrDefaultAsync(TKey id);

      IEnumerable<T> All();
      Task<IEnumerable<T>> AllAsync();

      bool Delete(T model);
      Task<bool> DeleteAsync(T model);
   }
}
