using Unity;
using Unity.Extension;
using Unity.Lifetime;

namespace Motherload.Factories
{
    /// <summary>
    /// Classe que lida com o DI
    /// </summary>
    public static class DependencyInjector
    {
        /// <summary>
        /// Unity Container
        /// </summary>
        private static readonly UnityContainer UnityContainer = new UnityContainer();

        /// <summary>
        /// Registra uma interface e classe juntas
        /// </summary>
        /// <typeparam name="I">Interface</typeparam>
        /// <typeparam name="T">Classe</typeparam>
        public static void Register<I, T>() where T : I
        {
            UnityContainer.RegisterType<I, T>(new ContainerControlledLifetimeManager());
        }

        /// <summary>
        /// Registra uma intância de uma interface
        /// </summary>
        /// <typeparam name="I">Interface</typeparam>
        /// <param name="instance">Instância</param>
        public static void InjectStub<I>(I instance)
        {
            UnityContainer.RegisterInstance(instance, new ContainerControlledLifetimeManager());
        }

        /// <summary>
        /// Retorna uma interface registrada pelo DI
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Retrieve<T>()
        {
            return UnityContainer.Resolve<T>();
        }

        /// <summary>
        /// Adiciona uma extensão para executar o registro de um serviço sem necessáriamente chamar pelo
        /// <see cref="Register{I, T}"/> diretamente.
        /// </summary>
        /// <typeparam name="T">Classe que herda <see cref="UnityContainerExtension"/></typeparam>
        public static void AddExtension<T>() where T : UnityContainerExtension
        {
            UnityContainer.AddNewExtension<T>();
        }
    }
}
