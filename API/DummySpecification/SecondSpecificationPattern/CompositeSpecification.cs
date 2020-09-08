namespace API.SecondSpecificationPattern
{
    public abstract class CompositeSpecification<T> : ISpecificationSecond<T>
    {
        public ISpecificationSecond<T> And(ISpecificationSecond<T> specification)
        {
           return new AndSpecification<T>(this, specification);
        }

       public abstract bool IsSatisfiedBy(T o);

        public ISpecificationSecond<T> Not(ISpecificationSecond<T> specification)
        {
            return new NotSpecification<T>(specification);
        }

        public ISpecificationSecond<T> Or(ISpecificationSecond<T> specification)
        {
            return new NotSpecification<T>(specification);
        }
    }
}