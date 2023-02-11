using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Library.Data;
using Library.Data.Models;
using Library.Utilites;
using System.Reflection;

namespace Library.Models
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions contextOptions) : base(contextOptions) { }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookDetail> BookDetails { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Libraryy> Library { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<City> City { get; set; }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> userRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string? connectionString = ConfigurationHelper.Config.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
