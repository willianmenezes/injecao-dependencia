using DependencyInjection.Generics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DependencyInjection
{
    public class Program
    {
        static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            VerificarTipoInjecaoDependencia(host.Services, "01 - ");
            VerificarTipoInjecaoDependencia(host.Services, "02 - ");

            host.Run();

        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureServices((_, services) =>
               {
                   services.AddTransient<IOperacaoTransient, Operacao>()
                         .AddScoped<IOperacaoScoped, Operacao>()
                         .AddSingleton<IOperacaoSingleton, Operacao>();

                   // configurando injeção com classes genéricas
                   services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
               });

        static void VerificarTipoInjecaoDependencia(IServiceProvider services, string scope)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            var transient = provider.GetRequiredService<IOperacaoTransient>();
            var scoped = provider.GetRequiredService<IOperacaoScoped>();
            var singleton = provider.GetRequiredService<IOperacaoSingleton>();

            var transient2 = provider.GetRequiredService<IOperacaoTransient>();
            var scoped2 = provider.GetRequiredService<IOperacaoScoped>();
            var singleton2 = provider.GetRequiredService<IOperacaoSingleton>();

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
