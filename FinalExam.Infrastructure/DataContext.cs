using FinalExam.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
