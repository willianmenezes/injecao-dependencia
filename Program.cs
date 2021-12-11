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
            new InjecaoDeDependencia().ExecutarMetodosDeTestes(args);
        }
    }
}
