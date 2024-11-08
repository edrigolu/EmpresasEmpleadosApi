using EmpresasEmpleadosApi.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpresasEmpleadosApi.Data.DBContext;

public partial class EmpresaEmpleadosDbContext : DbContext
{
    public EmpresaEmpleadosDbContext()
    {
    }

    public EmpresaEmpleadosDbContext(DbContextOptions<EmpresaEmpleadosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<EmpresaEmpleado> EmpresaEmpleados { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRol> MenuRoles { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=EmpresaEmpleadosDb;Trusted_Connection=True; TrustServerCertificate=True;");
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado);

            entity.ToTable("Empleado");

            entity.HasIndex(e => e.NumDocumento, "UNIQUE_Empleado").IsUnique();

            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa);

            entity.ToTable("Empresa");

            entity.Property(e => e.NombreEmpresa)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmpresaEmpleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpresaEmpleado).HasName("PK_EmpleadoEmpresa");

            entity.ToTable("EmpresaEmpleado");

            entity.Property(e => e.EstadoRegistro).HasDefaultValue(true);

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.DetalleEmpleados)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK_EmpleadoEmpresa_Empleado");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.DetalleEmpresa)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK_EmpleadoEmpresa_Empresa");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu);

            entity.ToTable("Menu");

            entity.Property(e => e.Icono)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MenuRol>(entity =>
        {
            entity.HasKey(e => e.IdMenuRol);

            entity.ToTable("MenuRol");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("FK_MenuRol_Menu");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.ToTable("Rol");

            entity.Property(e => e.RolDescripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Clave).IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_Usuario_Rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
