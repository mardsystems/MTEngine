using Microsoft.EntityFrameworkCore;
using MTEngine.Regras;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTEngine
{
    public class MTEngineDbContext : DbContext
    {
        public DbSet<Regra> Regras { get; set; }

        public MTEngineDbContext(DbContextOptions<MTEngineDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Regra>()
                .HasKey(p => p.Nome);

            modelBuilder.Entity<Regra>()
                .Property(p => p.Nome)
                .ValueGeneratedNever();

            modelBuilder.Entity<Regra>().HasData(
                new Regra
                {
                    Nome = "Rio",
                    PathDeCidades = "/corpo/cidade",
                    PathDoNomeDaCidade = "nome",
                    PathDoNumeroDeHabitantesDaCidade = "populacao",
                    PathDeBairros = "bairros/bairro",
                    PathDoNomeDoBairro = "nome",
                    PathDoNumeroDeHabitantesDoBairro = "populacao",
                    TipoDeFormato = TipoDeFormato.Xml
                },
                new Regra
                {
                    Nome = "Minas",
                    PathDeCidades = "/body/region/cities/city",
                    PathDoNomeDaCidade = "name",
                    PathDoNumeroDeHabitantesDaCidade = "population",
                    PathDeBairros = "neighborhoods/neighborhood",
                    PathDoNomeDoBairro = "name",
                    PathDoNumeroDeHabitantesDoBairro = "population",
                    TipoDeFormato = TipoDeFormato.Xml
                },
                new Regra
                {
                    Nome = "Acre",
                    PathDeCidades = "/cities",
                    PathDoNomeDaCidade = "name",
                    PathDoNumeroDeHabitantesDaCidade = "population",
                    PathDeBairros = "neighborhoods",
                    PathDoNomeDoBairro = "name",
                    PathDoNumeroDeHabitantesDoBairro = "population",
                    TipoDeFormato = TipoDeFormato.JSON
                }
            );
        }
    }
}
