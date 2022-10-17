using FilesUploadApi.Dtos.Validation;

namespace FilesUploadApi.Dtos
{
    public class ImagineUploadRequest
    {
        [MaxFileSize(5*1024*1024)]
        [AllowedExtensions(new[] { ".png", ".jpg", ""})]
        public IFormFile Image { get; set; }
    }
}
