using Motherload.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Models
{
    /// <summary>
    /// Classe que será responsável por segurar as informações de configuração.
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Key para acessar as configurações salva
        /// </summary>
        [JsonIgnore]
        private readonly static string PREFS_KEY = "PREFS_CONFIG_KEY";

        /// <summary>
        /// Nome padrão da pasta onde ficará salva as configurações do jogo
        /// </summary>
        [JsonIgnore]
        private readonly static string CONFIG_FOLDER_NAME = "\\Motherload";

        /// <summary>
        /// Nome padrão da pasta onde ficará salva as configurações relátivas as layers.
        /// </summary>
        [JsonIgnore]
        private readonly static string LAYERS_FOLDER_NAME = "\\Layers";

        /// <summary>
        /// Nome padrão da pasta onde ficará salva as configurações relátivas aos tiles de cada layer.
        /// </summary>
        [JsonIgnore]
        private readonly static string LAYERS_TILES_FOLDER_NAME = "\\Tiles";

        /// <summary>
        /// Nome padrão do arquivo onde ficará salva as layers existentes no jogo.
        /// </summary>
        [JsonIgnore]
        private readonly static string LAYER_FILE_NAME = "\\Layers.json";

        /// <summary>
        /// Nome padrão do arquivo onde ficará salva as layers existentes no jogo.
        /// </summary>
        [JsonIgnore]
        private readonly static string ORES_FILE_NAME = "\\Ores.json";

        /// <summary>
        /// Caminho padrão para a pasta de configurações.
        /// </summary>
        public string BasePath { get; set; }

        /// <summary>
        /// Caminho onde as informações de cada camada será salva.
        /// </summary>
        public string LayersFilePath { get; set; }

        /// <summary>
        /// Caminho da pasta onde os piso de cada camada será salvo.
        /// </summary>
        public string LayerTilesFolderPath { get; set; }
        
        /// <summary>
        /// Caminho onde o arquivo que conterá informações sobre os minérios está salvo.
        /// </summary>
        public string OresFilePath { get; set; }

        /// <summary>
        /// Inicializa as configurações e retorna a string serializada das configurações.
        /// </summary>
        /// <returns></returns>
        public static string Initialize()
        {
            // Gera um caminho base para o %APPDATA% apontando para a pasta de configuração do jogo
            var basePath = Path.GetFullPath(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + CONFIG_FOLDER_NAME);

            Debug.Log($"Caminho padrão: {basePath}");

            // Verifica se o diretório base existe
            if (!Directory.Exists(basePath))
                // Se não, cria o diretório base
                Directory.CreateDirectory(basePath);

            // Caminho do diretório onde será salvo questões relativas as Layers
            var layerPath = Path.GetFullPath(basePath + LAYERS_FOLDER_NAME);

            // Verifica se o diretório das layers existe
            if (!Directory.Exists(layerPath))
                // Se não, cria o diretório das layers
                Directory.CreateDirectory(layerPath);

            // Caminho para o arquivo json onde conterá as informações das layers
            var layersFilePath = Path.GetFullPath(layerPath + LAYER_FILE_NAME);

            // Verifica se o arquivo das layers existe
            if (!File.Exists(layersFilePath))
                // Se não, cria um arquivo json e escreve as layers padrões obtidas do GameResources
                File.WriteAllText(layersFilePath, Resources.Load<TextAsset>("Config/Layers").text);

            // Caminho do diretório onde será salvo as informações dos tiles de cada layer
            var layerTilesPath = Path.GetFullPath(layerPath + LAYERS_TILES_FOLDER_NAME);

            // Verifica se o diretório existe
            if (!Directory.Exists(layerTilesPath))
                // Se não, cria o diretório do layerTiles
                Directory.CreateDirectory(layerTilesPath);

            // Caminho para o arquivo json que conterá as informações sobre os minérios
            var oresFilePath = Path.GetFullPath(basePath + ORES_FILE_NAME);

            // Verifica se o arquivo existe
            if (!File.Exists(oresFilePath))
                // Se não, cria um arquivo json e escreve os ores padrões obtidos do GameResources
                File.WriteAllText(oresFilePath, Resources.Load<TextAsset>("Config/Ores").text);

            // Serializa uma nova instância das configurações
            var configs = JsonConvert.SerializeObject(new Config()
            {
                BasePath = basePath,
                LayersFilePath = layersFilePath,
                LayerTilesFolderPath = layerTilesPath,
                OresFilePath = oresFilePath
            }, Formatting.None);

            // Salva as configurações serializadas no PlayerPrefs
            PlayerPrefs.SetString(PREFS_KEY, configs);

            return configs;
        }

        /// <summary>
        /// Retorna as configurações
        /// </summary>
        /// <returns></returns>
        public static Config GetConfig()
        {
            return JsonConvert.DeserializeObject<Config>(PlayerPrefs.HasKey(PREFS_KEY) ? PlayerPrefs.GetString(PREFS_KEY) : Initialize());
        }
    }
}
