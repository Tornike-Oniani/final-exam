using FinalExam.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("data source=.;initial catalog=FinalExam;trusted_connection=true");
            }
        }

        public DbSet<Product> Products { get; set; }
    }
}
