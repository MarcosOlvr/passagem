using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Passagem.Data;
using Passagem.Models;

namespace Passagem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _db;

        public DashboardController(AppDbContext db)
        {
            _db = db;
        }

        // GET: DashboardController
        public IActionResult News()
        {
            var vm = new NewsIndexViewModel();
            vm.ListaCategoria = _db.Categorias.ToList();
            vm.ListaNoticias = _db.Noticias.ToList();

            return View(vm);
        }

        // GET: DashboardController/Create
        public IActionResult Create()
        {
            var vm = new NewsViewModel();            
            vm.ListaCategoria = _db.Categorias.ToList();

            return View(vm);
        }

        // POST: DashboardController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NewsViewModel obj)
        {
            ModelState.Remove("Noticias.Categoria");

            var categoriaById = _db.Categorias.Find(obj.Noticias.CategoriaFK);

            if (categoriaById != null)
                obj.Noticias.Categoria = categoriaById;

            if (ModelState.IsValid)
            {
                _db.Noticias.Add(obj.Noticias);
                _db.SaveChanges();
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

            var vm = new NewsViewModel();
            vm.ListaCategoria = _db.Categorias.ToList();

            var objNews = _db.Noticias.Find(id);
            
            if (objNews == null)
                return NotFound();

            vm.Noticias = objNews;

            return View(vm);
        }

        // POST: DashboardController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(NewsViewModel obj)
        {
            ModelState.Remove("Noticias.Categoria");

            var categoriaById = _db.Categorias.Find(obj.Noticias.CategoriaFK);

            if (categoriaById != null)
                obj.Noticias.Categoria = categoriaById;

            if (ModelState.IsValid)
            {
                _db.Noticias.Update(obj.Noticias);
                _db.SaveChanges();

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

            var objNews = _db.Noticias.Find(id);
            if (objNews == null)
                return NotFound();

            return View(objNews);
        }

        // POST: DashboardController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var obj = _db.Noticias.Find(id);
            if (obj == null)
                return NotFound();

            _db.Noticias.Remove(obj);
            _db.SaveChanges();

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

        [HttpGet]
        public IActionResult Emails()
        {
            var mensagens = _db.Emails.ToList();
            return View(mensagens);
        }

        [HttpGet]
        public IActionResult VisualizarEmail(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var obj = _db.Emails.Find(id);
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        [HttpPost]
        [Route("Dashboard/VisualizarEmail/{id}")]
        public IActionResult DeleteEmail(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var obj = _db.Emails.Find(id);

            if (obj == null)
                return NotFound();

            _db.Emails.Remove(obj);
            _db.SaveChanges();

            TempData["success"] = "Mensagem deletada com sucesso!";

            return RedirectToAction("Emails");
        }
    }
}
