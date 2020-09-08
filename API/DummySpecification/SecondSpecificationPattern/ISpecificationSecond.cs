namespace API.SecondSpecificationPattern
{
    public interface ISpecificationSecond<T>
    {
         bool IsSatisfiedBy(T o);
         ISpecificationSecond<T> And(ISpecificationSecond<T> specification);
         ISpecificationSecond<T> Or(ISpecificationSecond<T> specification);
         ISpecificationSecond<T> Not(ISpecificationSecond<T> specification);
    }
}