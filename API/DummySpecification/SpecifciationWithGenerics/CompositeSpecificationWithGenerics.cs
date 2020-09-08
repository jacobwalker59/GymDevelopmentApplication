namespace API.Specification.SpecifciationWithGenerics
{
    public abstract class CompositeSpecificationWithGenerics<T> : ISpecificationWithGenerics<T>
    {
    
    /*

    protected readonly List<ISpecification<TCandidate>> _childSpecifications = new List<ISpecification<TCandidate>>();

    public void AddChildSpecification(ISpecification<TCandidate> childSpecification)
    {
        _childSpecifications.Add(childSpecification);
    }

    // so what we have here is a bunch of speficiations we can run through and the possibilty to add them

    */
       public abstract bool IsSatisfiedBy(T candidate);
        public ISpecificationWithGenerics<T> And(ISpecificationWithGenerics<T> other) => new AndSpecificationWithGenerics<T>(this, other);
        public ISpecificationWithGenerics<T> AndNot(ISpecificationWithGenerics<T> other) => new AndNotSpecificatioWithGenerics<T>(this, other);
        public ISpecificationWithGenerics<T> Or(ISpecificationWithGenerics<T> other) => new OrSpecificationWithGenerics<T>(this, other);
        public ISpecificationWithGenerics<T> OrNot(ISpecificationWithGenerics<T> other) => new OrNotSpecificationWithGenerics<T>(this, other);
        public ISpecificationWithGenerics<T> Not() => new NotSpecificationWithGenerics<T>(this);
       
    }
}