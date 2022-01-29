using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Passagem.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        
        public string Nome { get; set; }

        [Required]
        public string NomeUsuario { get; set; }
        
        [Required]
        public string Senha { get; set; }

        [ForeignKey("Cargo")]
        public int CargoFK { get; set; }
        public virtual Cargos Cargo { get; set; }
    }
}
