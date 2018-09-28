using Motherload.Interfaces.Unity;
using UnityEngine;

namespace Assets.Services
{
    /// <summary>
    /// Implementação de <see cref="IResourceLoader"/>
    /// </summary>
    public class ResourceLoader : IResourceLoader
    {
        /// <summary>
        /// Implementação de <see cref="IResourceLoader.LoadJson(string)"/>
        /// </summary>
        public string LoadJson(string path) => Resources.Load<TextAsset>(path).text;
    }
}
