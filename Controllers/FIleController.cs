using AutoMapper;
using DriveAPI.BussinesServices;
using DriveAPI.Models;
using DriveAPI.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DriveAPI.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IFileBS _fileBS;
        private IFileStorageBS _fileStorageBS;
        private IMapper _mapper;
        public FileController(IFileBS fileBS, IFileStorageBS fileStorageBS, IMapper mapper)
        {
            _fileBS = fileBS;
            _fileStorageBS = fileStorageBS;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public Filew GetFileInfo(long id)
        {
            return _fileBS.GetFile(id);
        }
        [HttpPost("[action]")]
        public List<Filew> GetFilesInfo(List<long> ids)
        {
            var filesInfo = new List<Filew>();
            foreach (long id in ids)
            {
                var file = _fileBS.GetFile(id);
                if (file != null)
                    filesInfo.Add(file);
            }
            return filesInfo;
        }

        [HttpGet("[action]")]
        public ActionResult GetFolderContent(string folderPath)
        {
            folderPath = folderPath.Replace("root", "");
            folderPath = folderPath.Replace('/', '\\');
            return Ok(
                new
                {
                    content = _fileStorageBS.GetFolderContent(folderPath),
                    files = _fileBS.GetFilesByFolderPath(folderPath)
                }
            );
        }
        // [HttpGet("[action]")]
        // public ActionResult GetFolderContent()
        // {
        //     string folderPath="";
        //     folderPath = folderPath.Replace('/', '\\');
        //     return Ok(
        //         new
        //         {
        //             content = _fileStorageBS.GetFolderContent(folderPath.Replace("/", "\\")),
        //             files = _fileBS.GetFilesByFolderPath(folderPath)
        //         }
        //     );
        // }
        [HttpPost("[action]")]
        public async Task<Filew> PostFile([FromForm] PFile completeFile)
        {
            completeFile.folderPath = completeFile.folderPath.Replace("root", ""); ;
            completeFile.folderPath = completeFile.folderPath.Replace('/', '\\');
            await _fileStorageBS.SaveFile(completeFile.file, completeFile.folderPath);
            var file = _mapper.Map<Filew>(completeFile);
            return _fileBS.PostFile(file);
        }
        // [HttpPut("[action]")]
        // public Filew PutFile(long id, Filew file)
        // {
        //     return _fileBS.PutFile(id, file);
        // }
        [HttpDelete("[action]")]
        public long DeleteFile(long id)
        {
            var file = _fileBS.GetFile(id);
            string filePath = Path.Combine(file.folderPath, file.name).Replace('/', '\\') + file.extension;
            // Delete bytes
            var result = _fileStorageBS.DeleteFile(filePath);
            if (result)
                // Delete from DB
                return _fileBS.DeleteFile(id);
            else
                return -1;
        }
        [HttpPost("[action]")]
        public bool CreateEmptyFolder(string folderPath)
        {
            return _fileStorageBS.CreateEmptyFolder(folderPath);
        }
    }
}