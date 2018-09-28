using Motherload.Interfaces.Unity;
using UnityEngine;

namespace Assets.Services
{
    /// <summary>
    /// Implementação de <see cref="IDebugger"/>
    /// </summary>
    public class Debugger : IDebugger
    {
        /// <summary>
        /// Implementação de <see cref="IDebugger.Log(string)"/>
        /// </summary>
        public void Log(string message) => Debug.Log(message);
    }
}
