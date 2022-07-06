using AlvesMello_IntraNet.Models;

namespace AlvesMello_IntraNet.Repositories.Interfaces;

public interface ISiteRepository
{
    IEnumerable<Site> Sites { get; }
    IEnumerable<Site> FavoriteSites { get; }
    Site GetSiteById(int siteId);
}
