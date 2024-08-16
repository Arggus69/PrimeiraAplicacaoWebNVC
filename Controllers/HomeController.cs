using Microsoft.AspNetCore.Mvc;
using PrimeiraAplicacaoWebNVC.Models;
using System.Diagnostics;

namespace PrimeiraAplicacaoWebNVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contato()
        {
            return View();
        }
        public IActionResult Usuario()
        {
            var lista = new List<Usuarios>()
            {
                new Usuarios() { id = 1 , nome = "Tio Patinhas", email = "tiopatinhas@gmail.com" },
                new Usuarios() { id = 2 , nome = "Tobias", email = "tobias@gmail.com" },
                new Usuarios() { id = 3 , nome = "Terezo", email = "terezo@gmail.com" },
            };

            var viewModel = new UsuariosViewModel() { listUsuario = lista };
            
            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
