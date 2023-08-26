namespace DriveAPI.ViewModels
{
    public class PFile 
    {
        public long id { get; set; }
        public string folderPath { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime modificationDate { get; set; }
        public IFormFile file { get; set; }
    }
}