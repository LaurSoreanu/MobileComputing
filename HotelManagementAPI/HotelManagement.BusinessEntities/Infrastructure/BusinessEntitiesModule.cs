using Autofac;
using System;
using System.Linq;

namespace HotelManagement.BusinessEntities.Infrastructure
{
    public class BusinessEntitiesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            string[] namespaces = new[]
            {
                "HotelManagement.BusinessEntities.Implementation",
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
