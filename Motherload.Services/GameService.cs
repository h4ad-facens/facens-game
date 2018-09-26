using Motherload.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motherload.Services
{
    public class GameService : IGameService
    {
        private readonly IFileManager FileManager;

        private readonly ITaskManager TaskManager;

        public GameService(IFileManager fileManager, ITaskManager taskManager)
        {
            FileManager = fileManager;
            TaskManager = taskManager;
        }
    }
}
