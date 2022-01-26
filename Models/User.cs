using System.ComponentModel.DataAnnotations;

namespace Passagem.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        public string Nome { get; set; }

        [Required]
        public string NomeUsuario { get; set; }
        
        [Required]
        public string Senha { get; set; }
        
        public virtual Cargos Cargo { get; set; }
    }
}
