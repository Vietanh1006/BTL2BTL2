
using MaiVietAnhBTH2.Models;
using Microsoft.EntityFrameworkCore;

namespace MaiVietAnhBTH2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Student {get; set;}
    }   
}