using BoardGameStats.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameStats.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public DbSet<Player> Player { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Play> Play { get; set; }
        public DbSet<PlayPlayer> PlayPlayer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Entityframeworkcore.sqlite
            //optionsBuilder.UseSqlite("Data Source=/C:/Users/username/source/repos/BoardGameStats/BoardGameStats/bin/Debug/testDb.db");
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BoardGameDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayPlayer>()
                .HasKey(pp => new { pp.PlayId, pp.PlayerId });

            modelBuilder.Entity<PlayPlayer>()
                .HasOne(pp => pp.Play)
                .WithMany(p => p.PlayerPlays)
                .HasForeignKey(pp => pp.PlayId);

            modelBuilder.Entity<PlayPlayer>()
                .HasOne(pp => pp.Player)
                .WithMany(p => p.PlayerPlays)
                .HasForeignKey(pp => pp.PlayerId);
        }
    }
}