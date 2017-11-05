using ProductManagement.App.Models;
using ProductManagement.Core.Models;
using ProductManagement.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.App.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public ActionResult Index()
        {
            var products = _productRepository.Get();
            return View(products);
        }

        public ActionResult Details(int id)
        {
            var product = _productRepository.Get(id);
            return View(product);
        }

        public ActionResult Create()
        {
            var productViewModel = new ProductViewModel();
            productViewModel.AllCategories = _categoryRepository.Get().ToList();
            productViewModel.SelectedCategories = new string[0];
            productViewModel.ProductCategories = new List<Category>();
            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            try
            {
                _productRepository.Add(model.Product, model.GetSelectedCategories());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
