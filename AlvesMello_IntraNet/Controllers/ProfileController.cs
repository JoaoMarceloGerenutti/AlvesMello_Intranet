using Microsoft.AspNetCore.Mvc;

namespace AlvesMello_IntraNet.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
