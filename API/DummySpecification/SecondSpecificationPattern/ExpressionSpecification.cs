using System;

namespace API.SecondSpecificationPattern
{
    public class ExpressionSpecification<T> : CompositeSpecification<T>
    {
        private Func<T, bool> expression;
        public ExpressionSpecification(Func<T, bool> expression)    {
        if (expression == null)
            throw new ArgumentNullException();
        else
            this.expression = expression;
    }
        public override bool IsSatisfiedBy(T o)
        {
            return this.expression(o);
            // just returns the actual thing itself remember in regards to expressions its going to 
            // return either true or false depending on whether or not its the correct expression regardless
        }
    }
}