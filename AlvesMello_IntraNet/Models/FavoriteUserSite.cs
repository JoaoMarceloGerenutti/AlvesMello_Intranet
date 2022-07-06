using System.ComponentModel.DataAnnotations;

namespace AlvesMello_IntraNet.Models
{
	public class FavoriteUserSite
	{
		public int FavoriteUserSiteId { get; set; }
		public Site Site { get; set; }

		[StringLength(200)]
		public string FavoriteSiteId { get; set; }
	}
}
