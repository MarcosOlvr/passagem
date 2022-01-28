using System.ComponentModel.DataAnnotations;

namespace Passagem.Models
{
    public class Categorias
    {
        [Key]
        public int Id { get; set; }
        public string Categoria { get; set; }
        public virtual List<Noticias> Noticias { get; set; }
    }
}
