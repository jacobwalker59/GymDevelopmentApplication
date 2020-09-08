namespace API.Specification.SpecifciationWithGenerics
{
    public class AndSpecificationWithGenerics<T> : CompositeSpecificationWithGenerics<T>
    {
        ISpecificationWithGenerics<T> left;
        ISpecificationWithGenerics<T> right;
        public AndSpecificationWithGenerics(ISpecificationWithGenerics<T> left,ISpecificationWithGenerics<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public override bool IsSatisfiedBy(T candidate) => left.IsSatisfiedBy(candidate) && right.IsSatisfiedBy(candidate);
        // in the event there are many specs which there derifnietly will be
        /*
        public override bool IsSatisfiedBy(TCandidate candidate)
        {
        if (!_childSpecifications.Any()) return false;

        foreach (var s in _childSpecifications)
        {
            if (!s.IsSatisfiedBy(candidate)) return false;
        }

        return true;
    }
        */
    }
}