using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Passagem.Models
{
    public class Noticias
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string ResumoMateria { get; set; }

        [Required]
        [Column(TypeName = "ntext")]
        public string Conteudo { get; set; }

        [Required]
        public virtual Categorias Categoria { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public DateTime AtualizadoEm { get; set; } = DateTime.Now;
    }
}