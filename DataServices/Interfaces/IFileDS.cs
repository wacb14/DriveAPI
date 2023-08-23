using DriveAPI.Models;

namespace DriveAPI.DataServices{
    public interface IFileDS{
        public Filew GetFile(int id);
        public Filew PostFile(Filew file);
        public Filew PutFile(int id, Filew file);
        public int DeleteFile(int id);
    }
}