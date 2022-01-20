using System.ComponentModel.DataAnnotations;

namespace Passagem.Models
{
    public class FaleConosco
    {
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; }
        
        [Required]
        public string Email { get; set; }

        public string Assunto { get; set; }

        [Required]
        public string Mensagem { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
