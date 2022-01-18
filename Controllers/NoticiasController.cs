using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Passagem.Models;

namespace Passagem.Controllers
{
    public class NoticiasController : Controller
    {
        private static List<Noticias> news = new List<Noticias>
        {
            new Noticias
            {
                Id = 1,
                Titulo = "Ginásio Poliesportivo recebe reforma",
                ResumoMateria = "Não sei oq escrever aqui mas espero que fique legal hahahahahha",
                Conteudo = "O ginásio Poliesportivo de Passagem/RN, o Luisão, passou por uma reforma recentemente! O que mudou foi " +
                "as cores do local, tanto na parte externa quanto na interna!",
                Categoria = "Esporte",
                CriadoEm = DateTime.Now,
                AtualizadoEm = DateTime.Now
            }
        };

        [HttpGet]
        public IActionResult Index()
        {
            return View(news);
        }

        [HttpGet]
        public IActionResult Visualizar(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            

            var obj = news.Find(x => x.Id == id);

            if (obj == null)
                return NotFound();

            return View(obj);
        }
    }
}
