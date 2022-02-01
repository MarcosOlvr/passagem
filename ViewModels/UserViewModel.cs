using Passagem.Models;

namespace Passagem.ViewModels
{
    public class UserViewModel
    {
        public User User { get; set; }
        public IEnumerable<Cargos> ListaCargos { get; set; }
    }

    public class UserListViewModel
    {
        public IEnumerable<User> ListaUser { get; set; }
        public IEnumerable<Cargos> ListaCargo { get; set; }
    }
}
