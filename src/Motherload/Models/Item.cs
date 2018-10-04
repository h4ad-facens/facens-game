using Motherload.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Motherload.Models
{
    /// <summary>
    /// Classe base para todo item
    /// </summary>
    public class Item
    {
        #region Properties

        /// <summary>
        /// ID único do item usado para identifica-lo
        /// </summary>
        public int UniqueID { get; set; }

        /// <summary>
        /// Nome do item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Caminho para a Sprite do item
        /// </summary>
        public ItemTypes Type { get; set; }

        /// <summary>
        /// Lista de atributos do item
        /// </summary>
        public List<Attribute> Attributes { get; set; }

        #endregion

        #region Helpers

        /// <summary>
        /// Verifica se há uma determinada key na lista de atributos
        /// </summary>
        /// <param name="key">Key do atributo</param>
        /// <returns></returns>
        public bool HasKey(string key)
        {
            return Attributes.Exists(o => o.Key == key);
        }

        /// <summary>
        /// Retorna o valor do atributo pela sua key.
        /// </summary>
        /// <typeparam name="T">Tipo do atributo buscado</typeparam>
        /// <param name="key">Key do atributo</param>
        /// <returns></returns>
        public T GetAttributeValue<T>(string key)
        {
            return (T)Convert.ChangeType(Attributes.First(o => o.Key == key).Value, typeof(T));
        }

        /// <summary>
        /// Atribui um valor a um atributo
        /// </summary>
        /// <param name="key">Key do atributo</param>
        /// <param name="value">Valor a ser atribuido</param>
        public void SetAttributeValue(string key, string value)
        {
            Attributes.ForEach(o => { if (o.Key == key) o.Value = value; });
        }

        #endregion
    }
}
