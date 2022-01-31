using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Passagem.Data;
using Passagem.Models;
using Passagem.ViewModels;

namespace Passagem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _db;

        public DashboardController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
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
                return View("Page404");

            var objNews = _db.Noticias.Find(id);
            if (objNews == null)
                return View("Page404");

            return View(objNews);
        }

        // POST: DashboardController/Delete/5
        [HttpPost]
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

        [Route("Dashboard/Passagem/Login")]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CreateUser()
        {
            var vm = new UserViewModel();
            vm.ListaCargos = _db.Cargos.ToList();

            return View(vm);
        }

        [HttpPost]
        public IActionResult CreateUser(UserViewModel obj)
        {
            ModelState.Remove("User.Cargo");

            var cargoById = _db.Cargos.Find(obj.User.CargoFK);

            if (cargoById != null)
                obj.User.Cargo = cargoById;

            if (ModelState.IsValid)
            {
                _db.Users.Add(obj.User);
                _db.SaveChanges();
                TempData["success"] = "Usuário criado com sucesso!";

                return RedirectToAction("Users");
            }

            return View(obj);
        }
        
        public IActionResult Users()
        {
            var vm = new UserListViewModel();
            vm.ListaUser = _db.Users.ToList();
            vm.ListaCargo = _db.Cargos.ToList();

            return View(vm);
        }

        [HttpGet]
        public IActionResult EditUser(int? id)
        {
            if (id == null || id == 0)
                return View("Page404");

            var vm = new UserViewModel();
            vm.ListaCargos = _db.Cargos.ToList();

            var objUser = _db.Users.Find(id);

            if (objUser == null)
                return View("Page404");

            if (objUser.CargoFK == 1)
                return View("Page404");

            vm.User = objUser;

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditUser(UserViewModel obj)
        {
            ModelState.Remove("User.Cargo");

            var cargoById = _db.Cargos.Find(obj.User.CargoFK);

            if (cargoById != null)
                obj.User.Cargo= cargoById;

            if (ModelState.IsValid)
            {
                _db.Users.Update(obj.User);
                _db.SaveChanges();

                TempData["success"] = "Usuário editado com sucesso!";

                return RedirectToAction("Users");
            }

            return View(obj);
        }

        public IActionResult DeleteUser(int? id)
        {
            if (id == null || id == 0)
                return View("Page404");

            var objUser = _db.Users.Find(id);
            if (objUser == null)
                return View("Page404");

            if (objUser.CargoFK == 1)
                return View("Page404");

            return View(objUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUser(int id)
        {
            var obj = _db.Users.Find(id);
            if (obj == null)
                return View("Page404");

            _db.Users.Remove(obj);
            _db.SaveChanges();

            TempData["success"] = "Usuário deletado com sucesso!";

            return RedirectToAction("Users");
        }

        public IActionResult Page404()
        {
            return View();
        }

    }
}
