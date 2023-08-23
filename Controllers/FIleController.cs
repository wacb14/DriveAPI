using DriveAPI.BussinesServices;
using DriveAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DriveAPI.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IFileBS _fileBS;
        public FileController(IFileBS fileBS)
        {
            _fileBS = fileBS;
        }

        [HttpGet]
        public Filew GetFile(int id)
        {
            return _fileBS.GetFile(id);
        }
        [HttpPost]
        public Filew PostFile(Filew file)
        {
            return _fileBS.PostFile(file);
        }
        [HttpPut]
        public Filew PutFile(int id, Filew file)
        {
            return _fileBS.PutFile(id, file);
        }
        [HttpDelete]
        public int DeleteFile(int id)
        {
            return _fileBS.DeleteFile(id);
        }
    }
}