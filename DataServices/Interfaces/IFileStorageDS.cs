namespace DriveAPI.DataServices{
    public interface IFileStorageDS{
        public Task<string> SaveFile(byte[] file, string container, string name, string extension);
        public bool DeleteFile(string path);
        public List<string> GetFolderContent(string folderPath);
    }
}