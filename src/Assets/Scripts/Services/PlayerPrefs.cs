using Motherload.Interfaces.Unity;

namespace Assets.Scripts.Services
{
    /// <summary>
    /// Implementação de <see cref="IPlayerPrefs"/>
    /// </summary>
    public class PlayerPrefs : IPlayerPrefs
    {
        /// <summary>
        /// Implementação de <see cref="IPlayerPrefs.Save"/>
        /// </summary>
        public void Save() => UnityEngine.PlayerPrefs.Save();

        /// <summary>
        /// Implementação de <see cref="IPlayerPrefs.DeleteAll"/>
        /// </summary>
        public void DeleteAll() => UnityEngine.PlayerPrefs.DeleteAll();

        /// <summary>
        /// Implementação de <see cref="IPlayerPrefs.DeleteKey(string)"/>
        /// </summary>
        public void DeleteKey(string key) => UnityEngine.PlayerPrefs.DeleteKey(key);
        
        /// <summary>
        /// Implementação de <see cref="IPlayerPrefs.SetInt(string, int)"/>
        /// </summary>
        public void SetInt(string key, int value) => UnityEngine.PlayerPrefs.SetInt(key, value);

        /// <summary>
        /// Implementação de <see cref="IPlayerPrefs.GetInt(string)"/>
        /// </summary>
        public int GetInt(string key) => UnityEngine.PlayerPrefs.GetInt(key);

        /// <summary>
        /// Implementação de <see cref="IPlayerPrefs.GetInt(string, int)"/>
        /// </summary>
        public int GetInt(string key, int defaultValue) => UnityEngine.PlayerPrefs.GetInt(key, defaultValue);

        /// <summary>
        /// Implementação de <see cref="IPlayerPrefs.SetFloat(string, float)"/>
        /// </summary>
        public void SetFloat(string key, float value) => UnityEngine.PlayerPrefs.SetFloat(key, value);

        /// <summary>
        /// Implementação de <see cref="IPlayerPrefs.GetFloat(string)"/>
        /// </summary>
        public float GetFloat(string key) => UnityEngine.PlayerPrefs.GetFloat(key);

        /// <summary>
        /// Implementação de <see cref="IPlayerPrefs.SetString(string, string)"/>
        /// </summary>
        public void SetString(string key, string value) => UnityEngine.PlayerPrefs.SetString(key, value);

        /// <summary>
        /// Implementação de <see cref="IPlayerPrefs.GetFloat(string, float)"/>
        /// </summary>
        public float GetFloat(string key, float defaultValue) => UnityEngine.PlayerPrefs.GetFloat(key, defaultValue);

        /// <summary>
        /// Implementação de <see cref="IPlayerPrefs.GetString(string)"/>
        /// </summary>
        public string GetString(string key) => UnityEngine.PlayerPrefs.GetString(key);
        
        /// <summary>
        /// Implementação de <see cref="IPlayerPrefs.GetString(string, string)"/>
        /// </summary>
        public string GetString(string key, string defaultValue) => UnityEngine.PlayerPrefs.GetString(key, defaultValue);

        /// <summary>
        /// Implementação de <see cref="IPlayerPrefs.HasKey(string)"/>
        /// </summary>
        public bool HasKey(string key) => UnityEngine.PlayerPrefs.HasKey(key);
    }
}
