using System.Linq;
using API.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;

            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

             query = specification.Includes.Aggregate(query,(current, include) => current.Include(include));
            
            query = specification.IncludeStrings.Aggregate(query,
                                (current, include) => current.Include(include));

            // right so here we are just doing it with a string that already exists

            // really need an idiots guide to aggregation here

            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.GroupBy != null)
            {
                query = query.GroupBy(specification.GroupBy).SelectMany(x => x);
            }

            // Apply paging if enabled
            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip)
                             .Take(specification.Take);
            }
            return query;

        }
    }
}