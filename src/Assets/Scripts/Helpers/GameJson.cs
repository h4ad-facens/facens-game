using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

namespace Motherload.Core.Helpers
{
    /// <summary>
    /// Classe que lida com Serialização e Deserialização em Json.
    /// </summary>
    public class GameJson
    {
        /// <summary>
        /// Serializa um arquivo para Json
        /// </summary>
        /// <param name="path">Arquivo para qual serializiar</param>
        /// <param name="value">Objeto a ser serializado</param>
        /// <returns></returns>
        public static bool Serialize(string file, object value)
        {
            try
            {
                File.WriteAllText(file, JsonConvert.SerializeObject(value, Formatting.None));

                return true;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                return false;
            }
        }

        /// <summary>
        /// Deserializa um arquivo Json.
        /// </summary>
        /// <typeparam name="T">Objeto a ser deserializado</typeparam>
        /// <param name="file">Arquivo json</param>
        /// <returns></returns>
        public static T Deserialize<T>(string file)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                throw e;
            }
        }
    }
}
