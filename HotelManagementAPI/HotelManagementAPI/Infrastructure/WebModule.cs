using Autofac;
using HotelManagement.BusinessService.Infrastracture;
using HotelManagement.Services.Infrastructure;
using HotelManagementAPI.Exceptions;
using Module = Autofac.Module;

namespace HotelManagementAPI.Infrastructure
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterModule(new BusinessServicesModule());
            builder.RegisterModule(new ServicesModule());
            builder.RegisterType<ExceptionType>().As<IExceptionType>()
                .SingleInstance().PreserveExistingDefaults();
        }
    }
}
