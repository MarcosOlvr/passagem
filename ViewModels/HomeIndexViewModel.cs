using Passagem.Models;

namespace Passagem.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Noticias> ListaNoticias { get; set; } 
        public Noticias UltimaNoticia { get; set; }
    }
}
