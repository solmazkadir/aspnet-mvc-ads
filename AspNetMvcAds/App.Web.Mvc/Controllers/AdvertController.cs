using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class AdvertController : Controller
    {
        [Route("/advert/title-slug")]
        public IActionResult Detail()
        {
            return View();
        }
        public IActionResult Search()
        {
            return View();
        }
       
    }
}
