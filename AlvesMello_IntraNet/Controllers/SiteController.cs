using AlvesMello_IntraNet.Models;
using AlvesMello_IntraNet.Repositories.Interfaces;
using AlvesMello_IntraNet.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AlvesMello_IntraNet.Controllers
{
    public class SiteController : Controller
    {
        private readonly ISiteRepository _siteRepository;

        public SiteController(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public IActionResult List(string category)
        {
            IEnumerable<Site> sites;
            string currentCategory = string.Empty;

			if (string.IsNullOrEmpty(category))
			{
                sites = _siteRepository.Sites.OrderBy(s => s.SiteId);
                currentCategory = "Todos os Sites";
			}
			else
			{
                sites = _siteRepository.Sites
                    .Where(s => s.Category.Name.Equals(category))
                    .OrderBy(s => s.Name
                );

                currentCategory = category;
			}

            var sitesListViewModel = new SiteListViewModel
            {
                Sites = sites,
                CurrentCategory = currentCategory
            };

            return View(sitesListViewModel);
        }

        public IActionResult Details(int siteId)
		{
            var site = _siteRepository.Sites
                .FirstOrDefault(s => s.SiteId.Equals(siteId)
            );

            return View(site);
		}
    }
}
