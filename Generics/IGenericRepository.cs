namespace DependencyInjection.Generics
{
    public interface IGenericRepository<T> where T : class
    {
        void Adicionar(T entity);
    }
}
