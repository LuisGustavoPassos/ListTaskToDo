using ToDo.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<TodoModel> Todos { get; set; }
    }
}