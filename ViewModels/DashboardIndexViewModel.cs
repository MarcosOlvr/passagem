using Passagem.Models;

namespace Passagem.ViewModels
{
    public class DashboardIndexViewModel
    {
        public IEnumerable<Noticias> Noticias { get; set; }
        public IEnumerable<FaleConosco> Emails { get; set; }
    }
}
