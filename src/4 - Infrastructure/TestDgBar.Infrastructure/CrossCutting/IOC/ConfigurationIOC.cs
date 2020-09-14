using Autofac;
using AutoMapper;
using TestDgBar.Application;
using TestDgBar.Application.Interfaces;
using TestDgBar.Application.Mappers;
using TestDgBar.Domain.Core.Interfaces.Repositories;
using TestDgBar.Domain.Core.Interfaces.Services;
using TestDgBar.Domain.Services;
using TestDgBar.Infrastructure.Data.Repositories;

namespace TestDgBar.Infrastructure.CrossCutting.IOC
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
                cfg.AddProfile(new DtoToModelMappingComanda());
                cfg.AddProfile(new ModelToDtoMappingComanda());
                cfg.AddProfile(new DtoToModelMappingComandaItem());
                cfg.AddProfile(new ModelToDtoMappingComandaItem());
                cfg.AddProfile(new DtoToModelMappingItem());
                cfg.AddProfile(new ModelToDtoMappingItem());
                cfg.AddProfile(new ModelToDtoMappingNotaFiscalComanda());
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }

        #endregion IOC
    }
}