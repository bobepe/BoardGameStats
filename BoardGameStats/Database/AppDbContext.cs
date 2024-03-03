using BoardGameStats.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameStats.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Play> Plays { get; set; }

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

            modelBuilder.Entity<Player>()
                .HasMany(p => p.Plays)
                .WithMany(g => g.Players)
                .UsingEntity(j =>
                {
                    j.ToTable("PlayerPlay"); // Nastavení jména spojovací tabulky
                    j.Property<int>("Score").IsRequired(); // Přidání sloupce Score
                });
        }
    }
}