using System.ComponentModel.DataAnnotations;

namespace Passagem.Models
{
    public class Cargos
    {
        [Key]
        public int Id { get; set; }
        public string Cargo { get; set; }
        public virtual ICollection<User> Usuario { get; set; }
    }
}
