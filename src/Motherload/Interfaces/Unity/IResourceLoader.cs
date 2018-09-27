namespace Motherload.Interfaces.Unity
{
    /// <summary>
    /// Lida com carregamento dos Resources
    /// </summary>
    public interface IResourceLoader
    {
        /// <summary>
        /// Carrega um arquivo json da pasta Assets/Resources
        /// </summary>
        /// <param name="path">Caminho para o resource</param>
        /// <returns></returns>
        string LoadJson(string path);
    }
}
