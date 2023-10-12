namespace FitnessWebApp.Web.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class BaseController : Controller
    {
        /// <summary>
        /// This method search in ClaimTypes and return NameIdentifier
        /// </summary>
        /// <returns>NameIdentifier</returns>
        public string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
