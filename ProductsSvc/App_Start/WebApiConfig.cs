using ApplicationLayer;
using DomainEntities;
using DomainService.Interfaces;
using DomainService.Services;
using Infrastructure.Repository;
using ProductsSvc.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace ProductsSvc
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            Register1(config);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static void Register1(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<ProductApplicationService>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<ProductService>();

            container.RegisterType<CustomerApplicationService>();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<CustomerService>();

            container.RegisterType<PurchaseApplicationService>();
            container.RegisterType<IPurchaseRepository, PurchaseRepository>();
            container.RegisterType<PurchaseService>();

            config.DependencyResolver = new UnityResolver(container);

            // Other Web API configuration not shown.
        }
    }
}
