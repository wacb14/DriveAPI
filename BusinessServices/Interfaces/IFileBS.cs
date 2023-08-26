using DriveAPI.Models;

namespace DriveAPI.BussinesServices
{
    public interface IFileBS{
        public Filew GetFile(long id);
        public Filew PostFile(Filew file);
        public Filew PutFile(long id, Filew file);
        public long DeleteFile(long id);
        public List<Filew> GetFilesByFolderPath(string folderPath);

    }    
}