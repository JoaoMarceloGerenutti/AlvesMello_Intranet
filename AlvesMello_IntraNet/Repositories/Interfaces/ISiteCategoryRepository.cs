using AlvesMello_IntraNet.Models;

namespace AlvesMello_IntraNet.Repositories.Interfaces;

public interface ISiteCategoryRepository
{
    IEnumerable<SiteCategory> SiteCategories { get; }
}
