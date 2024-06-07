using InitialAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InitialAPI.Context
{
    public class FormsContext : DbContext
    {
        public FormsContext(DbContextOptions<FormsContext> options)
        : base(options)
        {
            
        }
        public DbSet<Form> Forms { get; set; }

        public DbSet<Field> Fields { get; set; }
    }
}
