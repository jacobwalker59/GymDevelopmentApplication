namespace API.SecondSpecificationPattern
{
    internal class AndSpecification<T> : CompositeSpecification<T>
    {
        private ISpecificationSecond<T> rightSpecification;
        private ISpecificationSecond<T> leftSpecification;

         public AndSpecification(ISpecificationSecond<T> left, ISpecificationSecond<T> right)  {
        this.leftSpecification = left;
        this.rightSpecification = right;
    }

    public override bool IsSatisfiedBy(T o)   {
        return this.leftSpecification.IsSatisfiedBy(o) 
            && this.rightSpecification.IsSatisfiedBy(o);
    }
    }
}