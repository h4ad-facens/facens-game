using Motherload.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.Extension;

namespace Motherload.Services.Factories
{

    public class DependencyOfDependencyExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IFileManager, BaseFileManager>();
            Container.RegisterType<ITaskManager, BaseTaskManager>();
        }

    }

}
