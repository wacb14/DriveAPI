using DriveAPI.DataServices;

namespace DriveAPI.BussinesServices
{
    public class FileBS : IFileBS
    {
        private IFileDS _fileDS;
        public FileBS(IFileDS fileDS)
        {
            _fileDS = fileDS;
        }
        public Filew GetFile(int id){
            return _fileDS.GetFile(id);
        }
        public Filew PostFile(Filew file){
            return _fileDS.PostFile(file);
        }
        public Filew PutFile(int id, Filew file){
            return _fileDS.PutFile(id, file);
        }
        public int DeleteFile(int id){
            return _fileDS.DeleteFile(id);
        }
    }
}