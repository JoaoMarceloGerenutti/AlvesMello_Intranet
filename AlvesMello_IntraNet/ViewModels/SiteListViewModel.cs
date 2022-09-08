using AlvesMello_IntraNet.Models;

namespace AlvesMello_IntraNet.ViewModels
{
	public class SiteListViewModel
	{
		public IEnumerable<Site> Sites { get; set; }
		public string CurrentDepartment { get; set; }
	}
}
