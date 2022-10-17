using FilesUploadApi.Models;

namespace FilesUploadApi.BusinessLogic
{
    public interface IImaginesService
    {
        Task<Image> AddImageAsync(byte[] imageBytes, string fileName, string contentType);
        Task<Image> GetImageAsync(int id);


    }
}
