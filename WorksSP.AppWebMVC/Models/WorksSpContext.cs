using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WorksSP.AppWebMVC.Models;

public partial class WorksSpContext : DbContext
{
    public WorksSpContext()
    {
    }

    public WorksSpContext(DbContextOptions<WorksSpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Contratista> Contratistas { get; set; }

    public virtual DbSet<OfertaTrabajo> OfertaTrabajos { get; set; }

    public virtual DbSet<PerfilTrabajo> PerfilTrabajos { get; set; }

    public virtual DbSet<SolicitarOferta> SolicitarOfertas { get; set; }

    public virtual DbSet<Trabajadore> Trabajadores { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Valoracione> Valoraciones { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=WorksSP;Integrated Security=True;Encrypt=False");*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC070F4B08EE");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Contratista>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contrati__3214EC0734C01DF5");

            entity.Property(e => e.Estado).HasDefaultValue((byte)1);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Contratista)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK1_Usuario_Contratista");
        });

        modelBuilder.Entity<OfertaTrabajo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OfertaTr__3214EC0760C86D41");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue((byte)1);
            entity.Property(e => e.FechaExpiracion).HasColumnType("datetime");
            entity.Property(e => e.FechaPublicacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.OfertaTrabajos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK1_Categoria_OfertaTrabajo");

            entity.HasOne(d => d.IdConstratistaNavigation).WithMany(p => p.OfertaTrabajos)
                .HasForeignKey(d => d.IdConstratista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK2_Constratista_OfertaTrabajo");
        });

        modelBuilder.Entity<PerfilTrabajo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PerfilTr__3214EC078BF81597");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue((byte)1);
            entity.Property(e => e.FechaExpiracion).HasColumnType("datetime");
            entity.Property(e => e.FechaPublicacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.PerfilTrabajos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK1_Categoria_PerfilTrabajo");

            entity.HasOne(d => d.IdTrabajadorNavigation).WithMany(p => p.PerfilTrabajos)
                .HasForeignKey(d => d.IdTrabajador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK2_Trabajador_PerfilTrabajo");
        });

        modelBuilder.Entity<SolicitarOferta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Solicita__3214EC07675E2B68");

            entity.Property(e => e.Comentario)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue((byte)1);

            entity.HasOne(d => d.IdOfertaTrabajoNavigation).WithMany(p => p.SolicitarOferta)
                .HasForeignKey(d => d.IdOfertaTrabajo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK1_OfertaTrabajo_SolicitarOferta");

            entity.HasOne(d => d.IdTrabajadorNavigation).WithMany(p => p.SolicitarOferta)
                .HasForeignKey(d => d.IdTrabajador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK2_Trabajador_SolicitarOferta");
        });

        modelBuilder.Entity<Trabajadore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trabajad__3214EC073FE4F9E1");

            entity.Property(e => e.Estado).HasDefaultValue((byte)1);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Trabajadores)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK1_Usuario_Trabajador");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC073C4E1B6D");

            entity.Property(e => e.Apellido)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Contrasena)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Usuario1)
                .HasDefaultValue((byte)1)
                .HasColumnName("Usuario");
        });

        modelBuilder.Entity<Valoracione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Valoraci__3214EC0797051F42");

            entity.Property(e => e.Calificacion).HasDefaultValue((byte)1);
            entity.Property(e => e.Comentario)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdContratistaNavigation).WithMany(p => p.Valoraciones)
                .HasForeignKey(d => d.IdContratista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK2_Contratista_Valoracion");

            entity.HasOne(d => d.IdPerfilTrabajoNavigation).WithMany(p => p.Valoraciones)
                .HasForeignKey(d => d.IdPerfilTrabajo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK1_PerfilTrabajo_Valoracion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
