using System;

namespace DependencyInjection
{
    public interface IOperacao
    {
        Guid Id { get; }
    } 

    public interface IOperacaoTransient : IOperacao { }
    public interface IOperacaoScoped : IOperacao { }
    public interface IOperacaoSingleton : IOperacao { }
}
