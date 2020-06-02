using Autofac;
using HotelManagement.BusinessEntities.Infrastructure;
using HotelManagement.DataServices.Infrastracture;
using HotelManagement.Services.Infrastructure;
using System;
using System.Linq;

namespace HotelManagement.BusinessService.Infrastracture
{
    public class BusinessServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new ServicesModule());
            builder.RegisterModule(new DataServicesModule());
            builder.RegisterModule(new BusinessEntitiesModule());
            string[] namespaces = new[]
            {
                "HotelManagement.BusinessService.Implementation",
				"HotelManagement.BusinessService.Authentification",
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
