using FilesUploadApi.Models;

namespace FilesUploadApi.Databse
{
    public interface IDbRepository_
    {
        Task AddImageAsync(Image image);
        Task<Image> GetImageAsync(int id);
        Task SaveChangesAsync();

    }
}
