using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MasterProject.Infrastructure.Data;
namespace Interview.Infrastructure
{
    public class DataContextFactory : IDesignTimeDbContextFactory<AppDBContext>
    {

        public AppDBContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDBContext>();
            builder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Data\\Study project\\MasterProject\\Master.Infrastructure\\App_Data\\Interviewdatabase.mdf\";Integrated Security=True");
            return new AppDBContext(builder.Options);
        }
    }
}
