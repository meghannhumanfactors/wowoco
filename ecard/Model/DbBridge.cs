using Microsoft.EntityFrameworkCore;

namespace ecard.Model
{
    public class DbBridge : DbContext
    {
        //DEFAULT CONSTRUCTOR
        public DbBridge() { }

        //CONSTRUCTOR - this is creating the database
        public DbBridge(DbContextOptions<DbBridge> options) : base(options) { }

        //Table in the Database if we want to create more we have to list them here
        //public DbSet<Enter-TableName-Here> Enter-TableName-Here { get; set;}
        public DbSet<Greetings> Greetings { get; set; }
    }
}
