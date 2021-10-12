using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MasterProject.Infrastructure.Data;

namespace Interview.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddDBContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<AppDBContext>(options =>
           options.UseSqlServer(connectionString));
    }
}
