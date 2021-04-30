using System;

namespace DependencyInjection
{
    public class Operacao : IOperacaoScoped, IOperacaoSingleton, IOperacaoTransient
    {
        public Operacao() : this(Guid.NewGuid()) { }

        public Operacao(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
