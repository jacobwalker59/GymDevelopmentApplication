namespace API.Specification.SpecifciationWithGenerics
{
    public class OrSpecificationWithGenerics<T> : CompositeSpecificationWithGenerics<T>
    {
        ISpecificationWithGenerics<T> left;
        ISpecificationWithGenerics<T> right;

        public OrSpecificationWithGenerics(ISpecificationWithGenerics<T> left, ISpecificationWithGenerics<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public override bool IsSatisfiedBy(T candidate) => left.IsSatisfiedBy(candidate) || right.IsSatisfiedBy(candidate);
    }
}