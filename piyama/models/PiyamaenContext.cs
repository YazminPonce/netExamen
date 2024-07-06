using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace piyama.models;

public partial class PiyamaenContext : DbContext
{
    public PiyamaenContext()
    {
    }

    public PiyamaenContext(DbContextOptions<PiyamaenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Piyama> Piyamas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__8A3D240C6B3A7521");

            entity.Property(e => e.IdCategoria)
                .ValueGeneratedNever()
                .HasColumnName("idCategoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Piyama>(entity =>
        {
            entity.HasKey(e => e.IdPiyama).HasName("PK__piyama__D7578CFF92329F97");

            entity.ToTable("piyama");

            entity.Property(e => e.IdPiyama)
                .ValueGeneratedNever()
                .HasColumnName("idPiyama");
            entity.Property(e => e.Descripción)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("descripción");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Imagen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("imagen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio).HasColumnName("precio");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Piyamas)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__piyama__idCatego__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
