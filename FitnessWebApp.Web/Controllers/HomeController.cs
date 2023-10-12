namespace FitnessWebApp.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;

    using FitnessWebApp.Web.ViewModels.Models;

    public class HomeController : BaseController
    {
       
        public IActionResult Index()
        {
            return RedirectToAction("All","Food");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}