using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentralDeErros.Api.Models;

namespace CentralDeErros.Api.Models
{
    public class CentralDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Microsservice> Microsservices { get; set; }
        public DbSet<Occurrence> Occurrences { get; set; }
        public DbSet<Perfil> Perfils { get; set; }

        public DbSet<CentralDeErros.Api.Models.Environment> Environments { get; set; }

        public CentralDbContext(DbContextOptions<CentralDbContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(p => p.UserId);

            modelBuilder.Entity<User>()
                .HasMany(k => k.Occurrences).WithOne(u => u.User);

            modelBuilder.Entity<Occurrence>()
                .HasKey(p => p.OccurrenceId);

            modelBuilder.Entity<Occurrence>()
                .HasOne(k => k.User).WithMany(s => s.Occurrences);

        }
    }
}
