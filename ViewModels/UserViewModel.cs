using Microsoft.AspNetCore.Identity;

namespace Passagem.ViewModels
{
    public class UserViewModel
    {
        public IEnumerable<IdentityUser> ListaUsers { get; set; }
    }
}
