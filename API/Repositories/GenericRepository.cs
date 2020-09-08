using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class GenericRepository<T> : IGenericRepo<T> where T : class
    {
        private readonly DataBaseContext _dataBase;
        public GenericRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dataBase.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dataBase.Set<T>().ToListAsync();
        }

         public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListOnlyAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }


        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
         
            return SpecificationEvaluator<T>.GetQuery(_dataBase.Set<T>().AsQueryable(),spec);

        }
    }
}