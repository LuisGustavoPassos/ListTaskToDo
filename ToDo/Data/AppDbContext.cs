using ToDo.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoModel> Todos{get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("Host=localhost;Database=ToDo;Username=postgres;Password=00449963#");
        }
    }
}