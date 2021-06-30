using Autofac;
using AutoMapper;
using eBar.Application;
using eBar.Application.Interfaces;
using eBar.Application.Mappers;
using eBar.Domain.Core.Interfaces.Repositories;
using eBar.Domain.Core.Interfaces.Services;
using eBar.Domain.Services;
using eBar.Infrastructure.Data.Repositories;

namespace eBar.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<ApplicationServiceComanda>().As<IApplicationServiceComanda>();
            builder.RegisterType<ApplicationServiceComandaItem>().As<IApplicationServiceComandaItem>();
            builder.RegisterType<ApplicationServiceItem>().As<IApplicationServiceItem>();
            builder.RegisterType<ServiceComanda>().As<IServiceComanda>();
            builder.RegisterType<ServiceComandaItem>().As<IServiceComandaItem>();
            builder.RegisterType<ServiceItem>().As<IServiceItem>();
            builder.RegisterType<ServiceComandaItemValidacao>().As<IServiceComandaItemValidacao>();
            builder.RegisterType<RepositoryComanda>().As<IRepositoryComanda>();
            builder.RegisterType<RepositoryComandaItem>().As<IRepositoryComandaItem>();
            builder.RegisterType<RepositoryItem>().As<IRepositoryItem>();
            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ComandaProfile());
                cfg.AddProfile(new ComandaItemProfile());
                cfg.AddProfile(new ItemProfile());
                cfg.AddProfile(new NotaFiscalProfile());
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }

        #endregion IOC
    }
}