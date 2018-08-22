using Microsoft.EntityFrameworkCore;

namespace HelloEF.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options){}
        public DbSet<Friend> Friends {get;set;}
    }
}