using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Passagem.Data;
using Passagem.Models;

namespace Passagem.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly AppDbContext _db;

        public NoticiasController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var news = _db.Noticias.ToList();
            return View(news);
        }

        [HttpGet]
        public IActionResult Visualizar(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            

            var obj = _db.Noticias.Find(id);

            if (obj == null)
                return NotFound();

            return View(obj);
        }
    }
}
