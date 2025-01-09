using Microsoft.EntityFrameworkCore;

namespace LibraryMemberFunction
{
    public class PubDb : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public PubDb(DbContextOptions<PubDb> options) : base(options)
        {
            
        }
    }
}
