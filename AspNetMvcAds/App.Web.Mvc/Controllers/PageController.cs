using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class PageController : Controller
    {
        //Route("/page/title-slug")]
        public IActionResult Detail()
        {
            return View();
        }
    }
}
