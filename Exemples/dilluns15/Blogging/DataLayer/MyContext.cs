using Microsoft.EntityFrameworkCore;

namespace Datalayer
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
        : base(options)
            {
            }

        public DbSet<Blog> Blogs => Set<Blog>();
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<AuditEntry> AuditEntries => Set<AuditEntry>();

    }

}
