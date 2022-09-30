using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region TablesConfig
            builder.Entity<Pokemon>().ToTable("Pokemons");
            builder.Entity<Region>().ToTable("Regions");
            builder.Entity<PokemonType>().ToTable("PokemonTypes");
            #endregion

            #region "Primary Keys"
            builder.Entity<Pokemon>().HasKey(p => p.Id);
            builder.Entity<Region>().HasKey(p => p.Id);
            builder.Entity<PokemonType>().HasKey(p => p.Id);
            #endregion

            #region "Relation Ships"
            builder.Entity<Region>()
                   .HasMany<Pokemon>(region => region.Pokemons)
                   .WithOne(pokemon => pokemon.Region)
                   .HasForeignKey(pokemon => pokemon.RegionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PokemonType>()
                .HasMany<Pokemon>(p => p.PrimaryType)
                .WithOne(p => p.PrimaryType)
                .HasForeignKey(pokemon => pokemon.PrimaryTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PokemonType>()
             .HasMany<Pokemon>(p => p.SecundaryType)
             .WithOne(p => p.SecundaryType)
             .HasForeignKey(pokemon => pokemon.SecundaryTypeId)
             .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region "Properties"
            builder.Entity<Pokemon>(p =>
            {
                p.Property(p => p.Name).IsRequired();
                p.Property(p => p.Name).HasMaxLength(25);
                p.Property(p => p.RegionId).IsRequired();
                p.Property(p => p.ImageUrl).IsRequired();
                p.Property(p => p.PrimaryTypeId).IsRequired();
                p.Property(p => p.SecundaryTypeId).IsRequired(false);
                //p.Property(p => p.SecundaryType).IsRequired(false);
            });
            builder.Entity<Region>(p =>
            {
                p.Property(p => p.Name).IsRequired();
                p.Property(p => p.Name).HasMaxLength(25);
            });
            builder.Entity<PokemonType>(p =>
            {
                p.Property(p => p.Name).IsRequired();
                p.Property(p => p.Name).HasMaxLength(25);
            });
            #endregion
        }
    }
}
