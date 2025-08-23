using CholitosAppFront.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CholitosAppFront.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IConnectionManagerRepository _connectionManagerRepository;

        //public HomeController(IConnectionManagerRepository connectionManagerRepository)
        //{
        //    this._connectionManagerRepository = connectionManagerRepository ?? throw new ArgumentNullException(nameof(connectionManagerRepository));
        //}

        public IActionResult Index()
        {
            return View(new ClientDto());
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}
    }
}
