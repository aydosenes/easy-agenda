using Autofac;
using Business.Services.Abstract;
using Business.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyTools
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AgendaService>().As<IAgendaService>().InstancePerDependency();
        }
    }
}
