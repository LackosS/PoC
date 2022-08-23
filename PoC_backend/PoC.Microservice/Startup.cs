using System.Web.Http;
using Owin;
using PoC.Microservice.Database;
using PoC.Microservice.Interfaces;
using PoC.Microservice.Mappers;
using PoC.Microservice.Services;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace PoC.Microservice
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration(); 
            config.Routes.MapHttpRoute( 
                name: "DefaultApi", 
                routeTemplate: "api/{controller}/{action}/{id}", 
                defaults: new { id = RouteParameter.Optional }
            );
            var container = new UnityContainer();
            container.RegisterType<IHaromszogRepository, HaromszogRepository>();
            container.RegisterType<IHaromszogMapper, HaromszogMapper>();
            container.RegisterType<IHaromszogService, HaromszogService>(new SingletonLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            appBuilder.UseWebApi(config);
            CreateDatabaseClass.CreateDataBase();
        }

        
        }

}