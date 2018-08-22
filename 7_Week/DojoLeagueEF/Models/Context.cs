using Microsoft.EntityFrameworkCore;

namespace DojoLeagueEF.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) :base(options){}
        public DbSet<Dojo> Dojos {get;set;}
        public DbSet<Ninja> Ninjas {get;set;}
    }
}