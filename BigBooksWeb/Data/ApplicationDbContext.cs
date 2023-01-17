using BigBooksWeb.Models;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace BigBooksWeb.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
