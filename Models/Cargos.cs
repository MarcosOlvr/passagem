using System.ComponentModel.DataAnnotations;

namespace Passagem.Models
{
    public class Cargos
    {
        [Key]
        public int CargoId { get; set; }
        public string CargoNome { get; set; }
        public virtual ICollection<User> Usuario { get; set; }
    }
}
