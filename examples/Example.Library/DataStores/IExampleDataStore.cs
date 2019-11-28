using System.Threading.Tasks;
using Example.Library.Models;
using XPike.DataStores;

namespace Example.Library.DataStores
{
    public interface IExampleDataStore
        : IDataStore
    {
        Task<User> GetExampleAsync(int id);

        Task<int?> CreateExampleAsync(User model);

        Task<bool> DeleteExampleAsync(int id);

        Task<bool> UpdateExampleAsync(User model);
    }
}