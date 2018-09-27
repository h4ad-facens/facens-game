namespace Motherload.Interfaces.Unity
{
    /// <summary>
    /// Interface que lida com depuração do jogo
    /// </summary>
    public interface IDebugger
    {
        /// <summary>
        /// Faz log de uma mensagem qualquer
        /// </summary>
        /// <param name="message">Mensagem a ser exibida no log</param>
        void Log(string message);
    }
}
