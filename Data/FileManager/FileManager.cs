namespace Passagem.Data.FileManager
{
    public class FileManager : IFileManager
    {
        private string _imagePath;

        public FileManager(IConfiguration config)
        {
            _imagePath = config["Path:Imagens"];
        }

        public FileStream ImageStream(string imagem)
        {
            return new FileStream(Path.Combine(_imagePath, imagem), FileMode.Open, FileAccess.Read);
        }

        public async Task<string> SaveImage(IFormFile imagem)
        {
            try
            {
                var save_path = Path.Combine(_imagePath);
                if (!Directory.Exists(_imagePath))
                {
                    Directory.CreateDirectory(save_path);
                }

                var mime = imagem.FileName.Substring(imagem.FileName.LastIndexOf('.'), 2);
                var fileName = $"img_{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}{mime}";

                using (var fileStream = new FileStream(Path.Combine(save_path, fileName), FileMode.Create))
                {
                    await imagem.CopyToAsync(fileStream);
                }

                return fileName;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Error";
            }
        }
    }
}
