using System.Linq;
using System.Threading.Tasks;

namespace NetCoreSample.Interfaces
{
    public interface IRepository<T, in TId> where T : class
    {
        T GetById(TId id);

        IQueryable<T> Get();

        void Add(T item);

        void Update(T item);

        void Delete(T item);

        Task SaveChangesAsync();
    }
}
