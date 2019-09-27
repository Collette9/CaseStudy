using Microsoft.EntityFrameworkCore;
using CaseStudy.Models;

namespace CaseStudy.Data
{
    public class AppUserContext : DbContext
    {
        public AppUserContext(DbContextOptions<AppUserContext> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }


    }
}
