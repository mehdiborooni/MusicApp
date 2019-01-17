
using MusicApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MusicApp.Data
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext(DbContextOptions<MusicDbContext> options): base(options) {}
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}
