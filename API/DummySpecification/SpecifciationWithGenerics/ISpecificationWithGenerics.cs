namespace API.Specification.SpecifciationWithGenerics
{
    public interface ISpecificationWithGenerics<T>
    {
        bool IsSatisfiedBy(T candidate);
        ISpecificationWithGenerics<T> And(ISpecificationWithGenerics<T> other);
        ISpecificationWithGenerics<T> AndNot(ISpecificationWithGenerics<T> other);
        ISpecificationWithGenerics<T> Or(ISpecificationWithGenerics<T> other);
        ISpecificationWithGenerics<T> OrNot(ISpecificationWithGenerics<T> other);
        ISpecificationWithGenerics<T> Not();

        //https://blog.jonblankenship.com/2019/10/04/using-the-specification-pattern-to-build-a-data-driven-rules-engine/
    
    }
}