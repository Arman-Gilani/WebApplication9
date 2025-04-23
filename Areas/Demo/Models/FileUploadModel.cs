namespace WebApplication9.Areas.Demo.Models
{
    public class FileUploadModel
    {
        public int FileID { get; set; }
        public string FilePath { get; set; }
        public IFormFile File { get; set; }
    }
}
