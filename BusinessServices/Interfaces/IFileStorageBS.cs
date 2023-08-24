namespace DriveAPI.BussinesServices
{   
    public interface IFileStorageBS{
        public Task<string> SaveFile(IFormFile file, string folderPath);
        public Task<string> ModifyFile(IFormFile file, string folderPath);
        public bool DeleteFile(string path);
    }    
}