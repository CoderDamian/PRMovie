using Microsoft.EntityFrameworkCore;
using Movies.WebClient.Models;

namespace Movies.WebClient.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base (options)
        {

        }


        public DbSet<Customer> Customers { get; set; }
    }
}
