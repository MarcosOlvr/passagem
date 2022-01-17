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

        // GET: NoticiasController
        public IActionResult News()
        {
            return View(news);
        }

        // GET: NoticiasController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NoticiasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Noticias obj)
        {         
            if (ModelState.IsValid)
            {
                news.Add(obj);
                return RedirectToAction("News");
            }

            return View(obj);
        }

        // GET: NoticiasController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var objNews = news.Find(x => x.Id == id);
            if (objNews == null)
                return NotFound();

            return View(objNews);
        }

        // POST: NoticiasController/Edit/5
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
                obj.AtualizadoEm = DateTime.Now;

                return RedirectToAction("Index");
            }

            return View(obj);
        }

        // GET: NoticiasController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var objNews = news.Find(x => x.Id == id);
            if (objNews == null)
                return NotFound();

            return View(objNews);
        }

        // POST: NoticiasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var obj = news.Find(x => x.Id == id);
            if (obj == null)
                return NotFound();

            news.Remove(obj);
            return RedirectToAction("News");
        }

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
