namespace DependencyInjection.Generics
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public void Adicionar(T entity)
        {
            // adicionar o objeto em qualquer bando de dados que for configurado
        }
    }
}
