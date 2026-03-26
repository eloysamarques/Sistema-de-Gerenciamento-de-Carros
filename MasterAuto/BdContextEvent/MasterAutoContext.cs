using System;
using System.Collections.Generic;
using MasterAuto.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterAuto.BdContextEvent;

public partial class MasterAutoContext : DbContext
{
    public MasterAutoContext()
    {
    }

    public MasterAutoContext(DbContextOptions<MasterAutoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carro> Carros { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MasterAuto;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carro>(entity =>
        {
            entity.HasOne(d => d.IdCategoriaNavigation).WithMany().HasConstraintName("FK__Carro__id_Catego__628FA481");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany().HasConstraintName("FK__Carro__id_Marca__6383C8BA");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A7B263BAE8DDA9CB");

            entity.Property(e => e.IdCategoria).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.IdMarca).HasName("PK__Marca__7A5E10D33F5A5960");

            entity.Property(e => e.IdMarca).HasDefaultValueSql("(newid())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
