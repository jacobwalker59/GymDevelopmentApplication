namespace API.Specification.SpecifciationWithGenerics
{
    public class OrNotSpecificationWithGenerics<T> : CompositeSpecificationWithGenerics<T>
    {
        ISpecificationWithGenerics<T> left;
        ISpecificationWithGenerics<T> right;

        public OrNotSpecificationWithGenerics(ISpecificationWithGenerics<T> left, ISpecificationWithGenerics<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public override bool IsSatisfiedBy(T candidate) => left.IsSatisfiedBy(candidate) || !right.IsSatisfiedBy(candidate);
    }
}