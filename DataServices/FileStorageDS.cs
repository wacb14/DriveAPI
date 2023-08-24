namespace DriveAPI.DataServices
{
    public class FileStorageDS : IFileStorageDS
    {
        // Provides information about the application's hosting environment, such as the path to the web content's root folder
        private readonly IWebHostEnvironment _webHostEnvironment;
        // Provides access to the current context of the HTTP request in which the application is located. It provides access to objects such as the request (HttpRequest), the response (HttpResponse) and other information related to the ongoing HTTP communication.
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FileStorageDS(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> SaveFile(byte[] file, string container, string name, string extension)
        {
            // Verifies if there's an error with the host path
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if(string.IsNullOrEmpty(wwwRootPath))
                throw new Exception();
            
            // Creates the folder if it doesn't exists
            string folderPath = Path.Combine(wwwRootPath, container);
            if(!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            // Defines the final file's path and writes all the bytes
            string finalName = $"{name}{extension}";
            string finalPath = Path.Combine(folderPath, finalName);
            await File.WriteAllBytesAsync(finalPath, file);

            // When the file is finally written, returns the relative path to save in the DB
            string pathDB = Path.Combine(container, finalName);
            return pathDB;

            /* // When the file is finally written, it defines the current app's URL and returns the complete URL of the file
            string currentUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            string fileUrl = Path.Combine(currentUrl, container, finalName);
            return fileUrl; */
        }
        public bool DeleteFile(string path)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            // Verifies if there's an error with the host path
            if(string.IsNullOrEmpty(wwwRootPath)){
                return false;
            }
            // Combine the host path with the relative file path
            string finalPath = Path.Combine(wwwRootPath, path);
            if(!File.Exists(finalPath))
                return false;
            else{
                File.Delete(finalPath);
                return true;
            }
        }
    }
}