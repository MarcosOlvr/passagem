using Microsoft.AspNetCore.Mvc;
using Passagem.Models;

namespace Passagem.Controllers
{
    public class DashboardController : Controller
    {
        public static List<Noticias> news = new List<Noticias>
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

        // GET: DashboardController
        public IActionResult News()
        {
            return View(news);
        }

        // GET: DashboardController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DashboardController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Noticias obj)
        {
            if (ModelState.IsValid)
            {
                news.Add(obj);
                TempData["success"] = "Notícia criada com sucesso!";

                return RedirectToAction("News");
            }

            return View(obj);
        }

        // GET: DashboardController/Edit/5
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var objNews = news.Find(x => x.Id == id);
            if (objNews == null)
                return NotFound();

            return View(objNews);
        }

        // POST: DashboardController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Noticias obj, int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var objNews = news.Find(x => x.Id == id);

            if (ModelState.IsValid)
            {
                objNews.Id = obj.Id;
                objNews.Titulo = obj.Titulo;
                objNews.Conteudo = obj.Conteudo;
                objNews.Categoria = obj.Categoria;
                objNews.CriadoEm = objNews.CriadoEm;
                objNews.AtualizadoEm = DateTime.Now;
                objNews.ResumoMateria = obj.ResumoMateria;

                TempData["success"] = "Notícia editada com sucesso!";

                return RedirectToAction("News");
            }

            return View(obj);
        }

        // GET: DashboardController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var objNews = news.Find(x => x.Id == id);
            if (objNews == null)
                return NotFound();

            return View(objNews);
        }

        // POST: DashboardController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var obj = news.Find(x => x.Id == id);
            if (obj == null)
                return NotFound();

            news.Remove(obj);

            TempData["success"] = "Notícia deletada com sucesso!";

            return RedirectToAction("News");
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Dashboard/Passagem/Login")]
        public IActionResult Login()
        {
            return View();
        }
        
        public static List<FaleConosco> mensagens = new List<FaleConosco>
        {
            new FaleConosco
            {
                Id = 1,
                NomeAutor = "Agostinho Carrara Taxi",
                Email = "agostinhocarrara@taxi.com",
                Assunto = "Frete",
                Mensagem = "Gostaria de saber se tem como cês fretar meu táxi, preciso ganhar dinheiro, tmj crias",
                CriadoEm = DateTime.Now,
            },
            new FaleConosco
            {
                Id = 2,
                NomeAutor = "Harry Porra",
                Email = "harryporra@bruxo.com",
                Assunto = "Clipe da minha música",
                Mensagem = "Gostaria de utilizar do campo de futebol de sua cidade para gravar meu novo lançamento musical, se possivel, sem pagar nenhum centavo!",
                CriadoEm = DateTime.Now,
            },
            new FaleConosco
            {
                Id = 3,
                NomeAutor = "Teste",
                Email = "teste@teste.com",
                Assunto = "Sei la porra",
                Mensagem = "Acabou a criativade foi mal não sei oq colocar",
                CriadoEm = DateTime.Now,
            },
            new FaleConosco
            {
                Id = 4,
                NomeAutor = "Eu mesmo",
                Email = "eu@eu.com",
                Assunto = "Quero um emprego",
                Mensagem = "Alguém me arruma um emprego, preciso ganhar dinheiro pra comprar minhas coisas, AAAA QUERIA IR JOGAR BOLAAAAAAAAAAAAA",
                CriadoEm = DateTime.Now,
            }
        };

        [HttpGet]
        public IActionResult Emails()
        {
            return View(mensagens);
        }

        public IActionResult VisualizarEmail(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var obj = mensagens.Find(x => x.Id == id);
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        public IActionResult DeleteEmail(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var obj = mensagens.Find(x => x.Id == id);

            if (obj == null)
                return NotFound();

            mensagens.Remove(obj);

            TempData["success"] = "Mensagem deletada com sucesso!";

            return RedirectToAction("Emails");
        }
    }
}
