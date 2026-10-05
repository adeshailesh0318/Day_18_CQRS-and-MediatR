using Day18_CQRS_MediatR_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Day18_CQRS_MediatR_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}