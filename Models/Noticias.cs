namespace Passagem.Models
{
    public class Noticias
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string ResumoMateria { get; set; }
        public string Conteudo { get; set; }
        public string Categoria { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public DateTime AtualizadoEm { get; set; } = DateTime.Now;
    }
}