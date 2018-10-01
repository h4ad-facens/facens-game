using Motherload.Factories;
using Motherload.Interfaces;
using Motherload.Interfaces.Unity;
using Motherload.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Motherload.Services
{
    /// <summary>
    /// Classe que lida com tudo relacionado ao jogo
    /// </summary>
    public class GameService : IGameService
    {
        #region Properties

        /// <summary>
        /// Interface de gerenciamento de arquivos
        /// </summary>
        private IFileManager FileManager;

        /// <summary>
        /// Interface de gerenciamento de tarefas
        /// </summary>
        private ITaskManager TaskManager;

        /// <summary>
        /// Interface que carrega os recursos da Unity
        /// </summary>
        private IResourceLoader ResourceLoader;

        /// <summary>
        /// Interface que lida com os logs
        /// </summary>
        private IDebugger Debugger;

        /// <summary>
        /// Interface que lida com armazenamento de informações no PlayerPrefs do Unity
        /// </summary>
        private IPlayerPrefs PlayerPrefs;

        /// <summary>
        /// Implemetanção de <see cref="IGameService.Configurations"/>
        /// </summary>
        public Config Configurations { get; set; }

        /// <summary>
        /// Implemetanção de <see cref="IGameService.Layers"/>
        /// </summary>
        public List<Layer> Layers { get; set; }

        /// <summary>
        /// Implemetanção de <see cref="IGameService.ChunksLoaded"/>
        /// </summary>
        public List<int[]> ChunksLoaded { get; set; }

        /// <summary>
        /// Implemetanção de <see cref="IGameService.Chunks"/>
        /// </summary>
        public List<Chunk> Chunks { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa o jogo
        /// </summary>
        public void Initilize()
        {
            FileManager = DependencyInjector.Retrieve<IFileManager>();
            TaskManager = DependencyInjector.Retrieve<ITaskManager>();
            ResourceLoader = DependencyInjector.Retrieve<IResourceLoader>();
            Debugger = DependencyInjector.Retrieve<IDebugger>();
            PlayerPrefs = DependencyInjector.Retrieve<IPlayerPrefs>();

            ChunksLoaded = new List<int[]>();
            Chunks = new List<Chunk>();
            LoadConfig();
        }

        #endregion

        #region Generators
        
        /// <summary>
        /// Gera os pisos de cada camada
        /// </summary>
        public void SaveChunks()
        {
            foreach (FileInfo file in new DirectoryInfo(Path.GetFullPath(Configurations.LayerTilesFolderPath)).GetFiles())
            {
                file.Delete();
            }
            
            byte[] inputBuffer = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(Chunks));
            byte[] outputBuffer = null;
        
            using (var outputFile = File.OpenWrite(Path.GetFullPath(Configurations.LayerTilesFolderPath + "//Chunks.lzf")))
            {
                // Compress input.
                int compressedSize = CLZF2.Compress(inputBuffer, ref outputBuffer);

                // Write compressed data to file.
                // Note the use of the size returned by Compress and not outputBuffer.Length.
                outputFile.Write(outputBuffer, 0, compressedSize);
            }
        }

        /// <summary>
        /// Carrega os Chunks salvos no HD.
        /// </summary>
        public void LoadChunks()
        {
            var pathFile = Path.GetFullPath(Configurations.LayerTilesFolderPath + "//Chunks.lzf");

            if (!File.Exists(pathFile))
                return;

            var chunksBytes = CLZF2.Decompress(File.ReadAllBytes(pathFile));
            Chunks = JsonConvert.DeserializeObject<List<Chunk>>(Encoding.ASCII.GetString(chunksBytes));
        }
        
        /// <summary>
        /// Inicializa as configurações e retorna a string serializada das configurações.
        /// </summary>
        /// <returns></returns>
        public string GenerateConfig()
        {
            // Gera um caminho base para o %APPDATA% apontando para a pasta de configurações do jogo
            var basePath = Path.GetFullPath(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Config.CONFIG_FOLDER_NAME);

            // Verifica se o diretório base existe
            if (!Directory.Exists(basePath))
                // Se não, cria o diretório base
                Directory.CreateDirectory(basePath);

            // Caminho do diretório onde será salvo questões relativas as Layers
            var layerPath = Path.GetFullPath(basePath + Config.LAYERS_FOLDER_NAME);

            // Verifica se o diretório das layers existe
            if (!Directory.Exists(layerPath))
                // Se não, cria o diretório das layers
                Directory.CreateDirectory(layerPath);

            // Caminho para o arquivo json onde conterá as informações das layers
            var layersFilePath = Path.GetFullPath(layerPath + Config.LAYER_FILE_NAME);
            // Verifica se o arquivo das layers existe
            if (!File.Exists(layersFilePath))
                // Se não, cria um arquivo json e escreve as layers padrões obtidas do GameResources
                File.WriteAllText(layersFilePath, ResourceLoader.LoadJson("Config/Layers"));

            // Caminho do diretório onde será salvo as informações dos tiles de cada layer
            var layerTilesPath = Path.GetFullPath(layerPath + Config.LAYERS_TILES_FOLDER_NAME);

            // Verifica se o diretório existe
            if (!Directory.Exists(layerTilesPath))
                // Se não, cria o diretório do layerTiles
                Directory.CreateDirectory(layerTilesPath);

            // Caminho para o arquivo json que conterá as informações sobre os minérios
            var oresFilePath = Path.GetFullPath(basePath + Config.ORES_FILE_NAME);

            // Verifica se o arquivo existe
            if (!File.Exists(oresFilePath))
                // Se não, cria um arquivo json e escreve os ores padrões obtidos do GameResources
                File.WriteAllText(oresFilePath, ResourceLoader.LoadJson("Config/Ores"));

            // Serializa uma nova instância dasconfigurações
            var configs = JsonConvert.SerializeObject(new Config()
            {
                BasePath = basePath,
                LayersFilePath = layersFilePath,
                LayerTilesFolderPath = layerTilesPath,
                OresFilePath = oresFilePath,
                MaxSpawnWorldHeight = -6,
                MaxSpawnWorldX = 84,
                MinSpawnWorldX = -52
        }, Formatting.None);

            // Salva as configurações serializadas no PlayerPrefs
            PlayerPrefs.SetString(Config.PREFS_KEY, configs);

            return configs;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Retorna as configurações
        /// </summary>
        /// <returns></returns>
        public Config GetConfig() => Configurations;

        /// <summary>
        /// Carrega as informações de configuração
        /// </summary>
        public void LoadConfig() => Configurations = JsonConvert.DeserializeObject<Config>(PlayerPrefs.HasKey(Config.PREFS_KEY) ? PlayerPrefs.GetString(Config.PREFS_KEY) : GenerateConfig());
        
        /// <summary>
        /// Carrega as layers
        /// </summary>
        public async Task LoadLayers()
        {
            foreach (var file in new DirectoryInfo(Path.GetFullPath(Configurations.LayerTilesFolderPath)).EnumerateFiles())
            {
                using (var stream = file.OpenText())
                {
                    var watch = new Stopwatch();
                    watch.Start();
                    

                    watch.Stop();
                    Debugger.Log($"Levou {watch.ElapsedMilliseconds} milisegundos para carregar o mapa.");
                }
            }
        }

        #endregion
    }
}
