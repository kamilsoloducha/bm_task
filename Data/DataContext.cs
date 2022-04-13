using Microsoft.EntityFrameworkCore;
using MvcTest.Models;

namespace TestMvc.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
}
