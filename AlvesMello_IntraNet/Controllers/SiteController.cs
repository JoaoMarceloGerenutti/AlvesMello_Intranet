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

        public IActionResult List(string department)
        {
            IEnumerable<Site> sites;
            string currentDepartment = string.Empty;

			if (string.IsNullOrEmpty(department))
			{
                sites = _siteRepository.Sites.OrderBy(s => s.SiteId);
                currentDepartment = "Todos os Sites";
			}
			else
			{
                sites = _siteRepository.Sites
                    .Where(s => s.Department.Name.Equals(department))
                    .OrderBy(s => s.Name
                );

                currentDepartment = department;
			}

            var sitesListViewModel = new SiteListViewModel
            {
                Sites = sites,
                CurrentDepartment = currentDepartment
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

        public ViewResult Search(string searchString)
        {
            IEnumerable<Site> sites;
            string currentDepartment = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                sites = _siteRepository.Sites.OrderBy(s => s.SiteId);
                currentDepartment = "Todos os Sites";
            }
            else
            {
                sites = _siteRepository.Sites
                        .Where(s => s.Name.ToLower().Contains(searchString.ToLower())
                );

                if (sites.Any())
                {
                    currentDepartment = "Sites";
                }
                else
                {
                    currentDepartment = "Nenhum Site foi Encontrado!";
                }
            }
            return View("~/Views/Site/List.cshtml", new SiteListViewModel
            {
                Sites = sites,
                CurrentDepartment = currentDepartment
            });
        }
    }
}
