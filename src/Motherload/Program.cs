using Motherload.Services.Factories;
using Motherload.Services.Interfaces;
using System;

namespace Motherload.Services
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DependencyInjector.Register<IFileManager, BaseFileManager>();
            DependencyInjector.Register<ITaskManager, BaseTaskManager>();
            DependencyInjector.AddExtension<DependencyOfDependencyExtension>();

            var test = DependencyInjector.Retrieve<IFileManager>().Test();
            Console.WriteLine(test);
        }
    }
}
