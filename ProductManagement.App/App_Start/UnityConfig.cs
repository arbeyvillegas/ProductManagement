using ProductManagement.App.Controllers;
using ProductManagement.Core.Enumerations;
using ProductManagement.Core.Repositories;
using ProductManagement.Persistence.DB.Contexts;
using System;
using System.Web.Mvc;
using Unity;

namespace ProductManagement.App
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IContext, Context>();
            container.RegisterType<ICategoryRepository, Persistence.DB.Repositories.CategoryRepository>(nameof(EStorageType.Database));
            container.RegisterType<IProductRepository, Persistence.DB.Repositories.ProductRepository>(nameof(EStorageType.Database));
            container.RegisterType<ICategoryRepository, Persistence.Memory.Repositories.CategoryRepository>(nameof(EStorageType.Memory));
            container.RegisterType<IProductRepository, Persistence.Memory.Repositories.ProductRepository>(nameof(EStorageType.Memory));
            container.RegisterType<IController, ProductController>("Product");
            container.RegisterType<IController, CategoryController>("Category");
        }
    }
}