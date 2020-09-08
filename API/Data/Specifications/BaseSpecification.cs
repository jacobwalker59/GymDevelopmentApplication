using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using API.Data.Interfaces;
using Microsoft.EntityFrameworkCore.Query;

namespace API.Data
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public BaseSpecification()
        {
        }
        public Expression<Func<T, bool>> Criteria {get;}

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
         public List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> ThenIncludes 
         {get;} = new List<Func<IQueryable<T>, IIncludableQueryable<T, object>>>();

        public List<string> IncludeStrings { get; } = new List<string>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public Expression<Func<T, object>> GroupBy { get; private set; }
        public int Take { get; private set; }

        public int Skip { get; private set; }
        public bool IsPagingEnabled{ get; private set; } = false;

        // protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        // {
        //     Includes.Add(includeExpression);
        // }

        protected void AddInclude(string includeString){  IncludeStrings.Add(includeString);}

        protected void AddOrderBy(Expression<Func<T,object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T,object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }

        //these methods need speciifed by our evaluator. 
        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }


    }
}