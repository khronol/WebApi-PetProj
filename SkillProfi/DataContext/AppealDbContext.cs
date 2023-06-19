using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkillProfi.Auth;
using SkillProfi.Models;

namespace SkillProfi.DataContext
{
    public class AppealDbContext : IdentityDbContext<User>
    {
        public AppealDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Appeal> Appeals { get; set; }
    }
}
