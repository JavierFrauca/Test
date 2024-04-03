using Microsoft.EntityFrameworkCore;
using TEST.Models;

namespace TEST.Data
{
    public partial class MiData(DbContextOptions<MiData> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Tabla1> Tabla1 { get; set; }
        public DbSet<Tabla2> Tabla2 { get; set; }
        public DbSet<Tabla3> Tabla3 { get; set; }
    }
}
