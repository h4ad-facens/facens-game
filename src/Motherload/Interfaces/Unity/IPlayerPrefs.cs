namespace Motherload.Interfaces.Unity
{
    /// <summary>
    /// Lida com assuntos relacionados ao Player
    /// </summary>
    public interface IPlayerPrefs
    {
        /// <summary>
        /// Salva as informações da memória no disco
        /// </summary>
        void Save();

        /// <summary>
        /// Deleta todas as informações salvas no PlayerPrefs
        /// </summary>
        void DeleteAll();

        /// <summary>
        /// Deleta uma informações espefica de acordo com sua key.
        /// </summary>
        /// <param name="key">Key da informação a ser deletada</param>
        void DeleteKey(string key);

        /// <summary>
        /// Armazena um valor inteiro no PlayerPrefs
        /// </summary>
        /// <param name="key">Key do valor a ser armazenado</param>
        /// <param name="value">Valor a ser armazenado</param>
        void SetInt(string key, int value);

        /// <summary>
        /// Retorna um valor inteiro salvo no PlayerPrefs
        /// </summary>
        /// <param name="key">Key do valor armazenado</param>
        /// <returns></returns>
        int GetInt(string key);

        /// <summary>
        /// Retorna um valor inteiro salvo no PlayerPrefs
        /// </summary>
        /// <param name="key">Key do valor armazenado</param>
        /// <param name="defaultValue">Valo padrão caso não encontre</param>
        /// <returns></returns>
        int GetInt(string key, int defaultValue);

        /// <summary>
        /// Armazena um valor flutuante no PlayerPrefs
        /// </summary>
        /// <param name="key">Key do valor a ser armazenado</param>
        /// <param name="value">Valor a ser armazenado</param>
        void SetFloat(string key, float value);

        /// <summary>
        /// Retorna um valor flutuante salvo no PlayerPrefs
        /// </summary>
        /// <param name="key">Key do valor armazenado</param>
        /// <returns></returns>
        float GetFloat(string key);

        /// <summary>
        /// Retorna um valor flutuante salvo no PlayerPrefs
        /// </summary>
        /// <param name="key">Key do valor armazenado</param>
        /// <param name="defaultValue">Valo padrão caso não encontre</param>
        /// <returns></returns>
        float GetFloat(string key, float defaultValue);

        /// <summary>
        /// Salva uma string no PlayerPrefs
        /// </summary>
        /// <param name="key">Key para a string</param>
        /// <param name="value">Valor da string</param>
        void SetString(string key, string value);

        /// <summary>
        /// Retorna uma string salva no PlayerPrefs
        /// </summary>
        /// <param name="key">Key do valor armazenado</param>
        /// <returns></returns>
        string GetString(string key);

        /// <summary>
        /// Retorna uma string salva no PlayerPrefs
        /// </summary>
        /// <param name="key">Key do valor armazenado</param>
        /// <returns></returns>
        string GetString(string key, string defaultValue);

        /// <summary>
        /// Verifica se existe uma key armazenada
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        bool HasKey(string key);
    }
}
