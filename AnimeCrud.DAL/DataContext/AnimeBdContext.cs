using System;
using System.Collections.Generic;
using AnimeCrud.EN;
using Microsoft.EntityFrameworkCore;

namespace AnimeCrud.DAL.DataContext;

public partial class AnimeBdContext : DbContext
{
    public AnimeBdContext()
    {
    }

    public AnimeBdContext(DbContextOptions<AnimeBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnimeBd> AnimeBds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnimeBd>(entity =>
        {
            entity.HasKey(e => e.IdAnime).HasName("PK__AnimeBD__190C88F6EE7B2CC9");

            entity.ToTable("AnimeBD");

            entity.Property(e => e.Categoria)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaLanzamiento).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
