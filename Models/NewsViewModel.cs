namespace Passagem.Models
{
    public class NewsViewModel
    {
        public Noticias Noticias { get; set; }
        public IEnumerable<Categorias> Categorias { get; set; }
    }
}
