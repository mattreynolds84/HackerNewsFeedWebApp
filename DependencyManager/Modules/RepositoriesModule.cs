using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using Module = Autofac.Module;
using System.Reflection;

namespace DependencyManager.Modules
{
    internal class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HackerNewsRepository>().As<IHackerNewsRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
