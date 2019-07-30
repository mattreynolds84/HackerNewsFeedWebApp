using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Module = Autofac.Module;

namespace DependencyManager.Modules
{
    public class HackerNewsModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<RepositoriesModule>();
            builder.RegisterModule<ServicesModule>();
        }
    }
}
