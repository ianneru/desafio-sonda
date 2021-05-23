using AutoMapper;
using DesafioSonda.Domain.Entities;
using DesafioSonda.Repositories;
using DesafioSonda.Application;
using DesafioSonda.Application.DTOs;
using DesafioSonda.Application.Interfaces;
using DesafioSonda.Application.Mapper;
using DesafioSonda.ViewModels;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Configuration;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DesafioSonda
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterDIAndMapper();
        }

        private void RegisterDIAndMapper()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClientesDTO, Clientes>().ReverseMap();
                cfg.CreateMap<CreateClientesViewModel, ClientesDTO>().ReverseMap();
                cfg.CreateMap<UpdateClientesViewModel, ClientesDTO>().ReverseMap();
            });

            var mapper = config.CreateMapper();

            container.RegisterInstance(mapper);

            container.Register<IClientesRepository>(() => new ClientesRepository(
                                                            ConfigurationManager.ConnectionStrings["DB"].ConnectionString), Lifestyle.Scoped);

            container.Register<IClientesService,ClientesService>();

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
