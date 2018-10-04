using Newtonsoft.Json;

namespace Motherload.Models
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
        public readonly static string PREFS_KEY = "PREFS_CONFIG_KEY";

        /// <summary>
        /// Nome padrão da pasta onde ficará salva as configurações do jogo
        /// </summary>
        [JsonIgnore]
        public readonly static string CONFIG_FOLDER_NAME = "\\Motherload";

        /// <summary>
        /// Nome padrão da pasta onde ficará salva as configurações relátivas as layers.
        /// </summary>
        [JsonIgnore]
        public readonly static string LAYERS_FOLDER_NAME = "\\Layers";

        /// <summary>
        /// Nome padrão da pasta onde ficará salva as configurações relátivas aos tiles de cada layer.
        /// </summary>
        [JsonIgnore]
        public readonly static string LAYERS_TILES_FOLDER_NAME = "\\Tiles";

        /// <summary>
        /// Nome padrão do arquivo onde ficará salva as layers existentes no jogo.
        /// </summary>
        [JsonIgnore]
        public readonly static string LAYER_FILE_NAME = "\\Layers.json";

        /// <summary>
        /// Nome padrão do arquivo onde ficará salva as informações dos items existentes jogo.
        /// </summary>
        public readonly static string ITEMS_FILE_NAME = "\\Items.json";

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
        /// Caminho onde o arquivo que conterá informações sobre os items.
        /// </summary>
        public string ItemsFilePath { get; set; }

        /// <summary>
        /// Altura máxima em que será gerado o mundo
        /// </summary>
        public int MaxSpawnWorldHeight { get; set; }

        /// <summary>
        /// Posição mínima em X que será gerado o mundo.
        /// </summary>
        public int MinSpawnWorldX { get; set; }

        /// <summary>
        /// Posição máxima em X que será gerado o mundo.
        /// </summary>
        public int MaxSpawnWorldX { get; set; }
    }
}
