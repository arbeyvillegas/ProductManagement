using ProductManagement.App.Models;
using ProductManagement.Core.Globals;
using ProductManagement.Core.Models;
using ProductManagement.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Unity;

namespace ProductManagement.App.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnityContainer _container;

        public ProductController(IUnityContainer container)
        {
            _container = container;
        }

        public ActionResult Index()
        {
            var productRepository = _container.Resolve<IProductRepository>(GlobalVariables.StorgeType);

            var products = productRepository.Get();
            return View(products);
        }

        public ActionResult Details(int id)
        {
            var productRepository = _container.Resolve<IProductRepository>(GlobalVariables.StorgeType);
            var product = productRepository.Get(id);
            return View(product);
        }

        public ActionResult Create()
        {
            var categoryRepository = _container.Resolve<ICategoryRepository>(GlobalVariables.StorgeType);

            var productViewModel = new ProductViewModel();
            productViewModel.AllCategories = categoryRepository.Get().ToList();
            productViewModel.SelectedCategories = new string[0];
            productViewModel.ProductCategories = new List<Category>();
            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            try
            {
                var productRepository = _container.Resolve<IProductRepository>(GlobalVariables.StorgeType);
                productRepository.Add(model.Product, model.GetSelectedCategories());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
