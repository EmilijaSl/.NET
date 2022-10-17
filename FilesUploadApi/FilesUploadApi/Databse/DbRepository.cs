using FilesUploadApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilesUploadApi.Databse
{
    public class DbRepository : IDbRepository_
    {
        private readonly FilesUploadDbContext _context;
        public DbRepository(FilesUploadDbContext context)
        {
            _context = context;   
        }


        public async Task AddImageAsync(Image image)
        {
            await _context.Images.AddAsync(image);
        }

        public async Task<Image> GetImageAsync(int id)
        {
            return await _context.Images.FirstOrDefaultAsync(id => id.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChanges();
        }
    }
}
