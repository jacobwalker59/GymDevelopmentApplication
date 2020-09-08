using System;
using System.Linq.Expressions;

namespace API.Specification.SpecifciationWithGenerics
{
    public abstract class LinqSpecification<T>: CompositeSpecificationWithGenerics<T>
    {
        public abstract Expression<Func<T, bool>> AsExpression();
        public override bool IsSatisfiedBy(T candidate) => AsExpression().Compile()(candidate);
    }
}