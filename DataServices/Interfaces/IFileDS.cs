using DriveAPI.Models;

namespace DriveAPI.DataServices{
    public interface IFileDS{
        public Filew GetFile(long id);
        public Filew PostFile(Filew file);
        public Filew PutFile(long id, Filew file);
        public long DeleteFile(long id);
    }
}