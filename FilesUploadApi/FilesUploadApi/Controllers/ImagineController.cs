using FilesUploadApi.BusinessLogic;
using FilesUploadApi.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilesUploadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImaginesService _imagesService;

        public ImageController(IImaginesService imagesService)
        {
            _imagesService = imagesService;
        }

        [HttpPost("Upload")]
        public async Task<ActionResult> UploadImage([FromForm] ImagineUploadRequest request)
        {
            using var memoryStream = new MemoryStream();
            request.Image.CopyTo(memoryStream);
            var imageBytes = memoryStream.ToArray();

            var savedImage = await _imagesService.AddImageAsync(imageBytes, request.Image.FileName, request.Image.ContentType);

            return Ok(savedImage.Id);
        }

        [HttpGet("Download")]
        public async Task<ActionResult> DownloadImage([FromQuery] int id)
        {
            var image = await _imagesService.GetImageAsync(id);
            return File(image.ImageBytes, image.ContentType);
        }
    }
}
