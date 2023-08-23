using DriveAPI.BussinesServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DriveAPI.Controllers{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FileController:ControllerBase{
        private IFileBS _fileBS;
        public FileController(IFileBS fileBS){
            _fileBS = fileBS;
        }
        
    }
}