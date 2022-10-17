using Microsoft.EntityFrameworkCore;

namespace FilesUploadApi.Databse
{
    public class FilesUploadDbContext:DbContext
    {
        public DbSet<byte[]> Images { get; set; }
        public FilesUploadDbContext(DbContextOptions options) : base(options)
        { 
        
        }
    }
}
