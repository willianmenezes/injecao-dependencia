using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjection
{
    public class InjecaoDeDependencia
    {
        public void ExecutarMetodosDeTestes(string[] args)
        {
            var servicerCollection = new ServiceCollection();

            servicerCollection
                .AddTransient<IOperacaoTransient, Operacao>()
                .AddScoped<IOperacaoScoped, Operacao>()
                .AddSingleton<IOperacaoSingleton, Operacao>();

            var serviceProvider = servicerCollection.BuildServiceProvider();

            VerificarTipoInjecaoDependencia(serviceProvider, "01 - ");
            VerificarTipoInjecaoDependencia(serviceProvider, "02 - ");
        }

        private void VerificarTipoInjecaoDependencia(IServiceProvider services, string scope)
        {
            using IServiceScope serviceScope = services.CreateScope();

            var transient = serviceScope.ServiceProvider.GetRequiredService<IOperacaoTransient>();
            var scoped = serviceScope.ServiceProvider.GetRequiredService<IOperacaoScoped>();
            var singleton = serviceScope.ServiceProvider.GetRequiredService<IOperacaoSingleton>();

            var transient2 = serviceScope.ServiceProvider.GetRequiredService<IOperacaoTransient>();
            var scoped2 = serviceScope.ServiceProvider.GetRequiredService<IOperacaoScoped>();
            var singleton2 = serviceScope.ServiceProvider.GetRequiredService<IOperacaoSingleton>();

            Console.WriteLine($"{scope}transient - { transient.Id}");
            Console.WriteLine($"{scope}scoped - { scoped.Id}");
            Console.WriteLine($"{scope}singleton - { singleton.Id}");

            Console.WriteLine("===========================================");

            Console.WriteLine($"{scope}transient - { transient2.Id}");
            Console.WriteLine($"{scope}scoped - { scoped2.Id}");
            Console.WriteLine($"{scope}singleton - { singleton2.Id}");

            Console.WriteLine("===========================================");
        }
    }
}
