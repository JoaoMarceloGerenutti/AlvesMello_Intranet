using AlvesMello_IntraNet.Models;
using AlvesMello_IntraNet.Repositories.Interfaces;
using AlvesMello_IntraNet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlvesMello_IntraNet.Controllers;

[Authorize]
public class FavoriteSiteController : Controller
{
    private readonly ISiteRepository _siteRepository;
    private readonly FavoriteSite _favoriteSite;

    public FavoriteSiteController(ISiteRepository siteRepository, FavoriteSite favoriteSite)
    {
        _siteRepository = siteRepository;
        _favoriteSite = favoriteSite;
    }

    public IActionResult Index()
    {
        var sites = _favoriteSite.GetFavoriteUserSites();
        _favoriteSite.FavoriteUserSites = sites;

        var favoriteSiteVM = new FavoriteSiteViewModel
        {
            FavoriteSite = _favoriteSite
        };

        return View(favoriteSiteVM);
    }

    public IActionResult AddSiteToFavoriteSite(int siteId)
    {
        var selectedSite = _siteRepository.Sites
                            .FirstOrDefault(s => s.SiteId == siteId);
        if (selectedSite != null)
        {
            _favoriteSite.AddToFavorite(selectedSite);
        }
        return RedirectToAction("Index");
    }

    public IActionResult RemoveSiteFromFavoriteSite(int siteId)
    {
        var selectedSite = _siteRepository.Sites
                            .FirstOrDefault(s => s.SiteId == siteId);
        if (selectedSite != null)
        {
            _favoriteSite.RemoveFromFavorite(selectedSite);
        }
        return RedirectToAction("Index");
    }
}
