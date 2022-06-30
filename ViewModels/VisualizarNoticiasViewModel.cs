using Passagem.Models;

namespace Passagem.ViewModels
{
    public class VisualizarNoticiasViewModel
    {
        public Noticias Noticia { get; set; } 
        public IEnumerable<Noticias> ListaNoticias { get; set; }
        public IEnumerable<Categorias> ListaCategorias { get; set; }
    }
}
