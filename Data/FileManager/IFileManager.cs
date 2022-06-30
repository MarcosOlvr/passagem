namespace Passagem.Data.FileManager
{
    public interface IFileManager
    {
        FileStream ImageStream(string imagem);
        Task<string> SaveImage(IFormFile imagem);
    }
}
