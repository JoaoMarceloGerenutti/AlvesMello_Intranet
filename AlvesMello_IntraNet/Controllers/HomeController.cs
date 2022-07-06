using AlvesMello_IntraNet.Models;
using AlvesMello_IntraNet.Repositories.Interfaces;
using AlvesMello_IntraNet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AlvesMello_IntraNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISiteRepository _siteRepository;

		public HomeController(ISiteRepository siteRepository)
		{
			_siteRepository = siteRepository;
		}

		public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                FavoriteSites = _siteRepository.FavoriteSites
            };
            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}