//using Microsoft.EntityFrameworkCore;

//namespace ecard.Model
//{
//    public class DbBridge : DbContext
//    {
//        //DEFAULT CONSTRUCTOR
//        public DbBridge() { }

//        //CONSTRUCTOR - this is creating the database
//        public DbBridge(DbContextOptions<DbBridge> options) : base(options) { }

//        //Table in the Database if we want to create more we have to list them here
//        //public DbSet<Enter-TableName-Here> Enter-TableName-Here { get; set;}
//        public DbSet<Greetings> Greetings { get; set; }
//    }
//}




using Microsoft.EntityFrameworkCore;

namespace ecard.Model
{
    public class DbBridge : DbContext
    {
        // WOWOCO: DEFAULT CONSTRUCTOR (JUST DO THIS!)
        public DbBridge() { }

        // WOWOCO: CONSTRUCTOR (JUST DO THIS!)
        public DbBridge(DbContextOptions<DbBridge> options) : base(options) { }

        // WOWOCO: TABLE IN THE DATABASE; EACH TABLE GETS ITS OWN LINE.You add a bunch of these model then database table we keep them the same name
        // public DbSet<ENTER-TABLENAME-HERE> ENTER-TABLENAME-HERE { get; set; }
        public DbSet<Greetings> Greetings { get; set; }
        public DbSet<Questions> Questions { get; set; }

    }
}
