using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Digests;
using PrimeiraAplicacaoWebNVC.Models;
using Servico;
using Servico.model;
using System.ComponentModel.DataAnnotations;
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
            var db = new Db();

            var listaTO = db.GetUsuarios();

            var listaUsuario = new List<Usuarios>();
            foreach (var usuarioTO in listaTO)
            {
                listaUsuario.Add(
                    new Usuarios() 
                    {  
                        id = usuarioTO.Id,
                        nome = usuarioTO.Nome
                    }
                );
            }


            var viewModel = new UsuariosViewModel() { listUsuario = listaUsuario };
            
            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult NovoUsuario(int? id)
        {
            Usuarios? usuario = null;

            if(id != null)
            {
                var db = new Db();
                
                var usuarioTO = db.GetUsuarioById(id.GetValueOrDefault());

                usuario = new Usuarios()
                {
                    id = usuarioTO.Id,
                    nome = usuarioTO.Nome,
                };
            }

            return View(usuario);
        }

        public IActionResult PersistirUsuario(int? id, string nome, string email)
        {

            var db = new Db();
            if (id == null)
            {
                var novoUsuario = new UsuarioTO()
                {
                    Nome = nome,
                };
                db.AddUsuario(novoUsuario);
            }
            else
            {
                var alterarUsuario = new UsuarioTO()
                {
                    Id = id.GetValueOrDefault(),
                    Nome = nome
                };

                db.UpdateUsuario(alterarUsuario);
            }
            return RedirectToAction("Usuario");
        }

        public IActionResult Deletar(int id)
        {
            var db = new Db();

            db.DeleteUsuario(id);

            return RedirectToAction("Usuario");
        }
    }
}
