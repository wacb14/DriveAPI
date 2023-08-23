using DriveAPI.Models;

namespace DriveAPI.DataServices
{
    public class FileDS : IFileDS
    {
        private GeneralContext _generalContext;
        public FileDS(GeneralContext generalContext)
        {
            _generalContext = generalContext;
        }
        public Filew GetFile(long id)
        {
            return _generalContext.File.Find(id);
        }
        public Filew PostFile(Filew file)
        {
            _generalContext.File.Add(file);
            _generalContext.SaveChanges();
            return _generalContext.File.FirstOrDefault(f => f.id == file.id);
        }
        public Filew PutFile(long id, Filew file)
        {
            if (file != null)
            {
                _generalContext.File.Update(file);
                _generalContext.SaveChanges();
            }
            return _generalContext.File.FirstOrDefault(f => f.id == file.id);
        }
        public long DeleteFile(long id){
            var file = _generalContext.File.FirstOrDefault(f => f.id == id);
            if (file != null)
            {
                _generalContext.File.Remove(file);
                _generalContext.SaveChanges();
                return id;
            }
            else
                return -1;
            
        }
    }
}