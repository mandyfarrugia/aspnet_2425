using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Data
{
    /// <summary>
    /// StudentDbContext is the gateway to the database.
    /// An instance of this class will be used to communicate with the database and its tables.
    /// You should never use the Presentation layer to issue commands to the database.
    /// A repository class within the DataAccess project will act as a middleman between the Presentation and the Data Access layer.
    /// Remember - segregation and separation of concerns!
    /// </summary>
    public class StudentDbContext : IdentityDbContext //IdentityDbContext consists of tables related to authentication.
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options) { }

        //Hold a reference to the model classes which will be mapped to their respective table counterparts by Entity Framework.
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Lazy Loading enables developers to access child tables within parent tables without the need of using a JOIN SQL statement.
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}