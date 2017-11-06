using ProductManagement.App.Models;
using ProductManagement.Core.Globals;
using System.Web.Mvc;

namespace ProductManagement.App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                StorageType = GlobalVariables.StorgeType
            };
            return View(homeViewModel);
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel homeViewModel)
        {
            GlobalVariables.StorgeType = homeViewModel.StorageType;
            homeViewModel.Message = $"Storage Type is set to {homeViewModel.StorageType}";
            return View(homeViewModel);
        }
    }
}