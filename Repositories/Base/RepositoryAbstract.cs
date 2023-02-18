using Dommel;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
namespace Repositories.Base
{
   public abstract class RepositoryAbstract<T, TKey> : IRepository<T, TKey> where T : class
   {
      private readonly IDbConnection _connection;

      public RepositoryAbstract(IDbConnection connection)
      {
         _connection = connection;
      }

      public IEnumerable<T> All()
      {
         return _connection.GetAll<T>();
      }

      public async Task<IEnumerable<T>> AllAsync()
      {
         return await _connection.GetAllAsync<T>();
      }

      public bool Delete(T model)
      {
         return _connection.Delete(model);
      }

      public async Task<bool> DeleteAsync(T model)
      {
         return await _connection.DeleteAsync(model);
      }

      public T FirstOrDefault(TKey id)
      {
         return _connection.Get<T>(id);
      }

      public async Task<T> FirstOrDefaultAsync(TKey id)
      {
         return await _connection.GetAsync<T>(id);
      }

      public TKey Insert(T model)
      {
         return (TKey)_connection.Insert(model);
      }

      public async Task<TKey> InsertAsync(T model)
      {
         var id = await _connection.InsertAsync(model);
         return (TKey)id;
      }

      public bool Update(T model)
      {
         return _connection.Update(model);
      }

      public async Task<bool> UpdateAsync(T model)
      {
         return await _connection.UpdateAsync(model);
      }
   }
}
