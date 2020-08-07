using Microsoft.AspNetCore.Mvc;

namespace Factory.Contollers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}