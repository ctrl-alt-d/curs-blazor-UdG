using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Datalayer
{
    public class MyContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer("Data Source=localhost;User Id=sa;Password=X1nGuXunG1;Initial Catalog=Divendres;Trusted_Connection=False;MultipleActiveResultSets=true");
            return new MyContext(optionsBuilder.Options);
        }
    }

}
