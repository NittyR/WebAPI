using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<UserInfoAngular> UserInfoAngulars { get; set; }

    }
}
