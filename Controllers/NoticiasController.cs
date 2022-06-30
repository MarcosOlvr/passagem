using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Passagem.Data;
using Passagem.Data.FileManager;
using Passagem.Models;
using Passagem.ViewModels;

namespace Passagem.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IFileManager _fileManager;

        public NoticiasController(AppDbContext db, IFileManager fileManager)
        {
            _db = db;
            _fileManager = fileManager;
        }

        [HttpGet("/Imagem/{imagem}")]
        public IActionResult Imagem (string imagem)
        {
            var mime = imagem.Substring(imagem.LastIndexOf('.') + 1);
            return new FileStreamResult(_fileManager.ImageStream(imagem), $"imagem/{mime}");
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vm = new NewsIndexViewModel();
            vm.ListaNoticias = _db.Noticias.ToList();
            vm.ListaCategoria = _db.Categorias.ToList();

            return View(vm);
        }

        [HttpGet]
        public IActionResult Visualizar(int? id)
        {
            var vm = new VisualizarNoticiasViewModel();

            if (id == null || id == 0)
                return NotFound();
            

            vm.Noticia = _db.Noticias.Find(id);

            if (vm.Noticia == null)
                return NotFound();

            vm.ListaNoticias = _db.Noticias.ToList();
            vm.ListaCategorias = _db.Categorias.ToList();

            return View(vm);
        }
    }
}
