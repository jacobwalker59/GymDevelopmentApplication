namespace API.SecondSpecificationPattern
{
    internal class NotSpecification<T> : CompositeSpecification<T>
    {
        private ISpecificationSecond<T> specification;

        public NotSpecification(ISpecificationSecond<T> specification)
        {
            this.specification = specification;
        }

        public override bool IsSatisfiedBy(T o)
        {
            throw new System.NotImplementedException();
        }
    }
}