using ProductManagement.App.Controllers;
using ProductManagement.Core.Repositories;
using ProductManagement.Persistence.DB.Contexts;
using ProductManagement.Persistence.DB.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace ProductManagement.App
{
    public static class Bootstrapper
    {

        public static IUnityContainer Initialise()

        {

            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()

        {
            var container = new UnityContainer();

            RegisterTypes(container);

            return container;

        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IContext, Context>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IController, ProductController>("Product");
            container.RegisterType<IController, CategoryController>("Category");
        }

    }
}