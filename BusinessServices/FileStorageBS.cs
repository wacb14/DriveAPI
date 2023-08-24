using DriveAPI.DataServices;

namespace DriveAPI.BussinesServices
{
    public class FileStorageBS : IFileStorageBS
    {
        private IFileStorageDS _fileStorageDS;
        public FileStorageBS (IFileStorageDS fileStorageDS)
        {
            _fileStorageDS = fileStorageDS;
        }
        public async Task<string> SaveFile(IFormFile file, string folderPath)
        {
            // Creates a memory stream and convert the file into array of bytes
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var fileBytes = stream.ToArray();

            // Gets the name and extension of the file
            var fullName = file.FileName;
            var name = Path.GetFileNameWithoutExtension(fullName);
            var extension = Path.GetExtension(fullName);            

            return await _fileStorageDS.SaveFile(fileBytes, folderPath, name, extension);
        }
        public async Task<string> ModifyFile(IFormFile file, string folderPath)
        {
            // Creates a memory stream and convert the file into array of bytes
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var fileBytes = stream.ToArray();

            // Gets the name and extension of the file
            var fullName = file.FileName;
            var name = Path.GetFileNameWithoutExtension(fullName);
            var extension = Path.GetExtension(fullName);            

            return await _fileStorageDS.SaveFile(fileBytes, folderPath, name, extension);
        }
        public bool DeleteFile(string path)
        {
            return _fileStorageDS.DeleteFile(path);
        }
    }
}