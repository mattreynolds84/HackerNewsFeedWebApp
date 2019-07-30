using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using BusinessLogic.Services;
using Module = Autofac.Module;

namespace DependencyManager.Modules
{
    internal class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HackerNewsService>().As<IHackerNewsService>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
