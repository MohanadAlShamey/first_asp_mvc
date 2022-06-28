using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace first_asp_mvc.Models
{
    public class DbApplication:IdentityDbContext<UserApplication,RoleApplication,string>
    {

        public DbApplication(DbContextOptions<DbApplication> options) : base(options)
        {
        }

        public DbSet<CategoryApplication> Categories { get; set; }
        public DbSet<ApplicationProduct> Products { get; set; }
    }
}
