using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Passagem.Data;
using Passagem.Data.FileManager;
using Passagem.Models;
using Passagem.ViewModels;

namespace Passagem.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IFileManager _fileManager;

        public DashboardController(AppDbContext db, IFileManager fileManager)
        {
            _db = db;
            _fileManager = fileManager;
        }

        public IActionResult Index()
        {
            var vm = new DashboardIndexViewModel();
            vm.Noticias = _db.Noticias.ToList();
            vm.Emails = _db.Emails.ToList();

            return View(vm);
        }

        // GET: DashboardController
        [HttpGet]
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
        public async Task<IActionResult> Create(NewsViewModel obj)
        {
            ModelState.Remove("Noticias.Categoria");
            ModelState.Remove("Noticias.Imagem");

            var categoriaById = _db.Categorias.Find(obj.Noticias.CategoriaFK);

            if (categoriaById != null)
                obj.Noticias.Categoria = categoriaById;

            if (obj.Imagem != null)
                obj.Noticias.Imagem = await _fileManager.SaveImage(obj.Imagem);

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
                return View("Page404");

            var vm = new NewsViewModel();
            vm.ListaCategoria = _db.Categorias.ToList();

            var objNews = _db.Noticias.Find(id);

            if (objNews == null)
                return View("Page404");

            vm.Noticias = objNews;

            return View(vm);
        }

        // POST: DashboardController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NewsViewModel obj)
        {
            ModelState.Remove("Noticias.Categoria");
            ModelState.Remove("Noticias.Imagem");

            var categoriaById = _db.Categorias.Find(obj.Noticias.CategoriaFK);

            if (categoriaById != null)
                obj.Noticias.Categoria = categoriaById;

            if (obj.Imagem != null)
                obj.Noticias.Imagem = await _fileManager.SaveImage(obj.Imagem);

            if (ModelState.IsValid)
            {
                _db.Noticias.Update(obj.Noticias);
                _db.SaveChanges();

                TempData["success"] = "Notícia editada com sucesso!";

                return RedirectToAction("News");
            }

            return View(obj);
        }

        // POST: DashboardController/Delete/5
        [HttpPost]
        [Route("Dashboard/News/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var obj = _db.Noticias.Find(id);
            if (obj == null)
                return View("Page404");

            _db.Noticias.Remove(obj);
            _db.SaveChanges();

            TempData["success"] = "Notícia deletada com sucesso!";

            return RedirectToAction("News");
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
                return View("Page404");

            var obj = _db.Emails.Find(id);
            if (obj == null)
                return View("Page404");

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Dashboard/VisualizarEmail/{id}")]
        public IActionResult DeleteEmail(int? id)
        {
            if (id == null || id == 0)
                return View("Page404");

            var obj = _db.Emails.Find(id);

            if (obj == null)
                return View("Page404");

            _db.Emails.Remove(obj);
            _db.SaveChanges();

            TempData["success"] = "Mensagem deletada com sucesso!";

            return RedirectToAction("Emails");
        }

        public IActionResult Page404()
        {
            return View();
        }

    }
}
