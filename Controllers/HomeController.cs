using Microsoft.AspNetCore.Mvc;
using Passagem.Models;
using System.Diagnostics;

namespace Passagem.Controllers
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

        [HttpGet]
        public IActionResult FaleConosco()
        {
            return View();
        }

        public static List<FaleConosco> mensagens = new List<FaleConosco>
        {
            new FaleConosco
            {
                Id = 1,
                Nome = "Agostinho Carrara Taxi",
                Email = "agostinhocarrara@taxi.com",
                Assunto = "Frete",
                Mensagem = "Gostaria de saber se tem como cês fretar meu táxi, preciso ganhar dinheiro, tmj crias",
                CriadoEm = DateTime.Now,
            }
        };

        [HttpPost]
        public IActionResult FaleConosco(FaleConosco obj)
        {
            if (ModelState.IsValid)
            {
                mensagens.Add(obj);
                TempData["success"] = "Mensagem enviada com sucesso!";

                return RedirectToAction("FaleConosco");
            }

            return View(obj);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}