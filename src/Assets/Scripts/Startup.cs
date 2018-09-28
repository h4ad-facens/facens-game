using Assets.Scripts.Services;
using Assets.Services;
using Motherload.Factories;
using Motherload.Interfaces.Unity;
using UnityEditor;
using Motherload;
using Motherload.Interfaces;

namespace Assets.Scripts
{
    /// <summary>
    /// Classe que inicializa junto com o jogo
    /// </summary>
    [InitializeOnLoad]
    public class Startup
    {
        /// <summary>
        /// Método que é chamado ao inicilizar o jogo
        /// </summary>
        static Startup()
        {
            Bootstrap.Init();

            RegisterDI();

            Load();
        }

        /// <summary>
        /// Registra as dependencias
        /// </summary>
        public static void RegisterDI()
        {
            DependencyInjector.Register<IResourceLoader, ResourceLoader>();
            DependencyInjector.Register<IDebugger, Debugger>();
            DependencyInjector.Register<IPlayerPrefs, PlayerPrefs>();
        }

        /// <summary>
        /// Carrega todas as informações necessárias.
        /// Posteriormente colocar a maioria dessas coisas quando clicar em carregar o mundo principal.
        /// </summary>
        public static void Load()
        {
            DependencyInjector.Retrieve<IGameService>().Initilize();
        }
    }
}
