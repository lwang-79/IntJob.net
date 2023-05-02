using IntJob.DataAccess.Models;

namespace IntJob.DataAccess.Data
{
    public interface IModelData<T>
    {
        Task<T> Create(T item);
        Task<T> Delete(int id);
        Task<T?> Get(int id);
        Task<IEnumerable<T>> List();
        Task<T> Update(T item);
    }
}