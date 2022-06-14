using Microsoft.EntityFrameworkCore;
using probne_kolokwium.Entities.Models;

namespace probne_kolokwium.Entities
{
    public class RepositoryContext : DbContext
    {
       
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musician>(e =>
            {
                e.ToTable("Musician");
                e.HasKey(e => e.IdMusician);

                e.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                e.Property(e => e.NickName).HasMaxLength(20).IsRequired(false);

                e.HasData(
                    new Musician
                    {
                        IdMusician = 1,
                        FirstName = "Michal",
                        LastName = "Kowalski",
                        NickName = "xD"
                    },
                    new Musician {
                        IdMusician = 2,
                        FirstName = "Adam",
                        LastName = "Spiewak",
                        
                    }
                ); ; ;
            });

   

            modelBuilder.Entity<MusicLabel>(e =>
            {
                e.ToTable("MusicLabel");
                e.HasKey(e => e.IdMusicLabel);

                e.Property(e => e.Name).HasMaxLength(50).IsRequired();
       

                e.HasData(
                    new MusicLabel
                    {
                        IdMusicLabel = 1,
                        Name = "APBDMaffija",
                        
                        
                    }
                );
            });

            modelBuilder.Entity<Album>(e =>
            {
                e.ToTable("Album");
                e.HasKey(e => e.IdAlbum);

                e.Property(e =>e.AlbumName ).HasMaxLength(30).IsRequired();
                e.Property(e => e.PublishDate).IsRequired();
                e.HasOne(e => e.MusicLabel).WithMany(e => e.Albums).HasForeignKey(e => e.IdMusicLabel).IsRequired();
                e.HasData(
                    new Album
                    {
                        IdAlbum = 1,
                        AlbumName = "nie wiem co robie",
                        PublishDate = System.DateTime.UtcNow,
                        IdMusicLabel = 1
                    }
                    
                );

            });

            modelBuilder.Entity<Track>(e =>
            {
                e.ToTable("Track");
                e.HasKey(e => e.IdTrack);

                e.Property(e => e.TrackName).HasMaxLength(20).IsRequired();
                e.Property(e => e.Duration).IsRequired();
                e.HasOne(e => e.Album).WithMany(e => e.Tracks).HasForeignKey(e => e.IdAlbum).IsRequired(false);

                e.HasData(
                    new Track
                    {
                        IdTrack = 1,
                        TrackName = "widelce",
                        Duration = 15
                    },
                    new Track
                    {
                        IdTrack = 2,
                        TrackName = "lyzki's",
                        Duration = 12,
                       IdAlbum = 1

                    },
                    new Track
                    {
                        IdTrack = 3,
                        TrackName = "Widelec 2",
                        Duration = 10
                    }
                );
            });

            modelBuilder.Entity<Musician_Track>(e =>
            {
                e.ToTable("Musician_Track");


                e.HasOne(e => e.Musician).WithMany(e => e.Musician_Track).HasForeignKey(e => e.IdMusician);
                e.HasOne(e => e.Track).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdTrack);
                e.HasData(
                    new Musician_Track
                    {
                        IdMusician = 1,
                        IdTrack = 1

                    },
                    new Musician_Track
                    {
                        IdMusician = 1,
                        IdTrack = 2,

                    },
                    new Musician_Track
                    {
                        IdMusician = 2,
                        IdTrack = 3
                    }

                );
                e.HasKey(e => new { e.IdMusician, e.IdTrack }); 
            });
        }
    }
}
