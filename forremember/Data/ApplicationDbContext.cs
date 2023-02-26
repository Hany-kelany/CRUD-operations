using forremember.Models;
using Microsoft.EntityFrameworkCore;

namespace forremember.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Item> Items { get; set; }
}
