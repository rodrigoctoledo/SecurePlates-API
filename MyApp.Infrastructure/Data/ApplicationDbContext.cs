using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MyApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Plate> Plates { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da tabela de usuários
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Email).IsRequired();
                entity.Property(u => u.SenhaHash).IsRequired();
            });

            // Configuração da tabela de placas
            modelBuilder.Entity<Plate>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Placa).IsRequired();
                entity.Property(p => p.Local).IsRequired();
                entity.Property(p => p.Horario).IsRequired();
                entity.HasOne(p => p.Usuario)
                      .WithMany()
                      .HasForeignKey(p => p.UsuarioId);
            });

            // Configuração da tabela de ocorrências
            modelBuilder.Entity<Ocorrencia>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Placa).IsRequired();
                entity.Property(o => o.Descricao).IsRequired();
                entity.HasOne(o => o.Usuario)
                      .WithMany()
                      .HasForeignKey(o => o.UsuarioId);
            });
        }
    }
}
