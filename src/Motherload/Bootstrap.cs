using System;
using Motherload.Factories;
using Motherload.Interfaces;
using Motherload.Services;

namespace Motherload
{
    /// <summary>
    /// Classe para inicilizar os serviços DI
    /// </summary>
    public class Bootstrap
    {
        /// <summary>
        /// Iniciliza e registra os serviços
        /// </summary>
        public static void RegisterDI()
        {
            DependencyInjector.Register<IFileManager, BaseFileManager>();
            DependencyInjector.Register<ITaskManager, BaseTaskManager>();
            DependencyInjector.Register<IGameService, GameService>();
            DependencyInjector.Register<IInventory, Inventory>();
            DependencyInjector.Register<IPlayer, Player>();
        }

        /// <summary>
        /// Inicializa o projeto
        /// </summary>
        public static void Init()
        {
            RegisterDI();
        }
    }
}
