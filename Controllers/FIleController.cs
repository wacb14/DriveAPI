using AutoMapper;
using DriveAPI.BussinesServices;
using DriveAPI.Models;
using DriveAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DriveAPI.Controllers
{


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
        public List<string> GetFolderContent(string folderPath)
        {
            return _fileStorageBS.GetFolderContent(folderPath.Replace("/", "\\"));
        }
        [HttpPost("[action]")]
        public async Task<Filew> PostFile([FromForm] PFile completeFile)
        {
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
            var result = _fileStorageBS.DeleteFile(filePath);
            if (result)
                return _fileBS.DeleteFile(id);
            else
                return -1;

        }
    }
}