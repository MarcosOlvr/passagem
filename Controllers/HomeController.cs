using Microsoft.AspNetCore.Mvc;
using Passagem.Data;
using Passagem.Models;
using System.Diagnostics;

namespace Passagem.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
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

        [HttpPost]
        public IActionResult FaleConosco(FaleConosco obj)
        {
            if (ModelState.IsValid)
            {
                _db.Emails.Add(obj);
                _db.SaveChanges();

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