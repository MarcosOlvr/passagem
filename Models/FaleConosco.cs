using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Passagem.Models
{
    public class FaleConosco
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [DisplayName("Nome")]
        public string NomeAutor { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        public string Assunto { get; set; }

        [Required]
        public string Mensagem { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
