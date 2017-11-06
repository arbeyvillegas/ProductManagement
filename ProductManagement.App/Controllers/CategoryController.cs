using ProductManagement.Core.Globals;
using ProductManagement.Core.Models;
using ProductManagement.Core.Repositories;
using System.Web.Mvc;
using Unity;

namespace ProductManagement.App.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnityContainer _container;

        public CategoryController(IUnityContainer container)
        {
            _container = container;
        }

        public ActionResult Index()
        {
            var categoryRepository = _container.Resolve<ICategoryRepository>(GlobalVariables.StorgeType);

            var categories = categoryRepository.Get();

            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                var categoryRepository = _container.Resolve<ICategoryRepository>(GlobalVariables.StorgeType);

                categoryRepository.Add(category);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
