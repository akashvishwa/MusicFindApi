namespace MusicFindApi.Model
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Songs> tbl_SongsApi { get; set; }

    }
}
