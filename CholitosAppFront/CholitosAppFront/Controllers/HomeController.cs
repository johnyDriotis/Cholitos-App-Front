using CholitosAppFront.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CholitosAppFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConnectionManagerRepository _connectionManagerRepository;

        public HomeController(IConnectionManagerRepository connectionManagerRepository)
        {
            this._connectionManagerRepository = connectionManagerRepository ?? throw new ArgumentNullException(nameof(connectionManagerRepository));
        }

        public IActionResult Index()
        {
            string conexionExitosa = "";

            conexionExitosa = _connectionManagerRepository.ConnectToDatabaseWithMessage();

            ViewData["MsjConexion"] = conexionExitosa; 

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
