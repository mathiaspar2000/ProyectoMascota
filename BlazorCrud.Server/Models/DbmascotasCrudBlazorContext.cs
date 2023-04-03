using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Server.Models;

public partial class DbmascotasCrudBlazorContext : DbContext
{
    public DbmascotasCrudBlazorContext()
    {
    }

    public DbmascotasCrudBlazorContext(DbContextOptions<DbmascotasCrudBlazorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Mascota> Mascota { get; set; }

    public virtual DbSet<Tipo> Tipos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.HasKey(e => e.IdMascota).HasName("PK__Mascota__5C9C26F0285BF0C5");

            entity.Property(e => e.FechaIngreso).HasColumnType("date");
            entity.Property(e => e.FechaSalida).HasColumnType("date");
            entity.Property(e => e.NombreDueño)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreMascota)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.IdTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mascota__IdTipo__412EB0B6");
        });

        modelBuilder.Entity<Tipo>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK__Tipo__9E3A29A53A5355C1");

            entity.ToTable("Tipo");

            entity.Property(e => e.TipoMascota)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
