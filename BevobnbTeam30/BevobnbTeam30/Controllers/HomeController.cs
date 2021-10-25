using Microsoft.AspNetCore.Mvc;

//TODO: Upddate this namespace to match your project name
namespace BevobnbTeam30.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
