using Microsoft.EntityFrameworkCore;
namespace DojoSecrets.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions o) : base(o) {}
        public DbSet<DSUser> Users {get;set;}
        public DbSet<Secret> Secrets {get;set;}
        public DbSet<Like> Likes {get;set;}
    }
}