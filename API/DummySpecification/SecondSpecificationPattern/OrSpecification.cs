namespace API.SecondSpecificationPattern
{
    internal class OrSpecification<T> : CompositeSpecification<T>
    {
        private CompositeSpecification<T> compositeSpecification;
        private ISpecificationSecond<T> specification;

        public OrSpecification(CompositeSpecification<T> compositeSpecification, ISpecificationSecond<T> specification)
        {
            this.compositeSpecification = compositeSpecification;
            this.specification = specification;
        }

        public override bool IsSatisfiedBy(T o)
        {
            throw new System.NotImplementedException();
        }
    }
}