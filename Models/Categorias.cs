using System.ComponentModel.DataAnnotations;

namespace Passagem.Models
{
    public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }
        public virtual ICollection<Noticias> Noticias { get; set; }
    }
}
