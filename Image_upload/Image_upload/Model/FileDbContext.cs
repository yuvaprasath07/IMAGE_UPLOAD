using Microsoft.EntityFrameworkCore;

namespace Image_upload.Model
{
    public class FileDbContext : DbContext
    {
        public FileDbContext(DbContextOptions<FileDbContext> options) : base(options)
        {

        }
        public DbSet<DetailsModel> IMAGE_DETAILS { get; set; }
    }
}
