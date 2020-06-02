using Autofac;
using System.Linq;

namespace HotelManagement.DataServices.Infrastracture
{
    public class DataServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            string[] namespaces = new[]
            {
                "HotelManagement.DataServices.Implementation"
            };

            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .Where(x => namespaces.Contains(x.Namespace))
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerDependency();
            builder.RegisterType<Entities>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
