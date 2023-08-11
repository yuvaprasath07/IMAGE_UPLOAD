using Image_upload.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Image_upload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileManagerController : ControllerBase
    {
        public readonly Imanageimage _iManageImage;

        public FileManagerController(Imanageimage iManageImage)
        {
            _iManageImage = iManageImage;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadFile(IFormFile Files)
        {
            var result = await _iManageImage.UploadFile(Files);
            return Ok(result);
        }
    }
}
