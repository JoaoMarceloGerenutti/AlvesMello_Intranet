using AlvesMello_IntraNet.Models;
using AlvesMello_IntraNet.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AlvesMello_IntraNet.Components
{
    public class FavoriteSiteSummary : ViewComponent
    {
        private readonly FavoriteSite _favoriteSite;

		public FavoriteSiteSummary(FavoriteSite favoriteSite)
		{
			_favoriteSite = favoriteSite;
		}

		public IViewComponentResult Invoke()
		{
			var sites = _favoriteSite.GetFavoriteUserSites();

			_favoriteSite.FavoriteUserSites = sites;

            var favoriteSiteVM = new FavoriteSiteViewModel
            {
                FavoriteSite = _favoriteSite
            };

            return View(favoriteSiteVM);
        }
    }
}
