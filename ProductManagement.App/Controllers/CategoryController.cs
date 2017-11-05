using ProductManagement.Core.Models;
using ProductManagement.Core.Repositories;
using System.Web.Mvc;

namespace ProductManagement.App.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ActionResult Index()
        {
            var categories = _categoryRepository.Get();
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
                _categoryRepository.Add(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
