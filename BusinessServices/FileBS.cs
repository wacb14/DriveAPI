using DriveAPI.DataServices;
using DriveAPI.Models;

namespace DriveAPI.BussinesServices
{
    public class FileBS : IFileBS
    {
        private IFileDS _fileDS;
        public FileBS(IFileDS fileDS)
        {
            _fileDS = fileDS;
        }
        public Filew GetFile(long id){
            return _fileDS.GetFile(id);
        }
        public Filew PostFile(Filew file){
            return _fileDS.PostFile(file);
        }
        public Filew PutFile(long id, Filew file){
            return _fileDS.PutFile(id, file);
        }
        public long DeleteFile(long id){
            return _fileDS.DeleteFile(id);
        }
    }
}