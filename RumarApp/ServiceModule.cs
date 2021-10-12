using Autofac;
using RumarApp.Infraestructure;
using RumarApp.Services;

namespace RumarApp
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Service>().As<IService>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<SecurityService>().As<ISecurityService>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<ClientService>().As<IClientService>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<BeneficiaryService>().As<IBeneficiaryService>()
                .InstancePerLifetimeScope();
        }
    }
}
