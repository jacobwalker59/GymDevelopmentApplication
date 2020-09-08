using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Data.Interfaces
{
    public interface IGenericRepo<T> where T:class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListOnlyAsync(ISpecification<T> spec);

         // get exercise list for a given training day is arguably the most important
         // once this is sorted, could do things like get all squats within a given time frame say a month
         // and use data to track them
    }
}