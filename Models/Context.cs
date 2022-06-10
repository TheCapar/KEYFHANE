using Microsoft.EntityFrameworkCore;

namespace KeyfHane.Models
{
    public class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-PARNI3R;Database=KeyfHaneDB;integrated security=true");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Music> Musics { get; set; }


    }
}
