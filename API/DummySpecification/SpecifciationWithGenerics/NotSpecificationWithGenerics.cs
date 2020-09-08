namespace API.Specification.SpecifciationWithGenerics
{
    public class NotSpecificationWithGenerics<T> : CompositeSpecificationWithGenerics<T>
    {
        ISpecificationWithGenerics<T> other;
        public NotSpecificationWithGenerics(ISpecificationWithGenerics<T> other) => this.other = other;
        public override bool IsSatisfiedBy(T candidate) => !other.IsSatisfiedBy(candidate);
    }
}