using Autofac;
using System;
using System.Linq;

namespace HotelManagement.Services.Infrastructure
{
    public class ServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            string[] namespaces = new[]
            {
                    "HotelManagement.Services.Implementation"
            };

            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .Where(x => namespaces.Contains(x.Namespace))
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerDependency();
        }
    }
}
