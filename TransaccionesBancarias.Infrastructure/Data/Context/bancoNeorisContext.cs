using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TransaccionesBancarias.Core.Entity;
using TransaccionesBancarias.Infrastructure.Data;

namespace TransaccionesBancarias.Infrastructure.Data.Context
{
    public partial class bancoNeorisContext : DbContext
    {
        public bancoNeorisContext()
        {
        }

        public bancoNeorisContext(DbContextOptions<bancoNeorisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Configuracion> Configuracion { get; set; } = null!;
        public virtual DbSet<Cuenta> Cuenta { get; set; } = null!;
        public virtual DbSet<Movimiento> Movimientos { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-776KT05\\SQLEXPRESS;Database=BancoNeoris;Trusted_Connection=true;MultipleActiveResultSets=true");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<Cliente>(entity =>
            //{
            //    entity.ToTable("Cliente");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.Contraseña)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasColumnName("contraseña");

            //    entity.Property(e => e.Estado).HasColumnName("estado");

            //    entity.Property(e => e.PersonaId).HasColumnName("personaId");

            //    entity.HasOne(d => d.Persona)
            //        .WithMany(p => p.Clientes)
            //        .HasForeignKey(d => d.PersonaId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Cliente_Persona");
            //});

            //modelBuilder.Entity<Configuracion>(entity =>
            //{
            //    entity.ToTable("Configuracion");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.Descripcion)
            //        .HasMaxLength(100)
            //        .IsUnicode(false)
            //        .HasColumnName("descripcion");

            //    entity.Property(e => e.Estado).HasColumnName("estado");

            //    entity.Property(e => e.Nombre)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasColumnName("nombre");

            //    entity.Property(e => e.Valor)
            //        .HasMaxLength(100)
            //        .IsUnicode(false)
            //        .HasColumnName("valor");
            //});

            //modelBuilder.Entity<Cuenta>(entity =>
            //{
            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.ClienteId).HasColumnName("clienteId");

            //    entity.Property(e => e.Estado).HasColumnName("estado");

            //    entity.Property(e => e.NumeroCuenta).HasColumnName("numeroCuenta");

            //    entity.Property(e => e.SaldoInicial).HasColumnName("saldoInicial");

            //    entity.Property(e => e.TipoCuenta).HasColumnName("tipoCuenta");

            //    entity.HasOne(d => d.Cliente)
            //        .WithMany(p => p.Cuenta)
            //        .HasForeignKey(d => d.ClienteId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Cuenta_Cliente");

            //    entity.HasOne(d => d.TipoCuentaNavigation)
            //        .WithMany(p => p.Cuenta)
            //        .HasForeignKey(d => d.TipoCuenta)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Cuenta_Configuracion");
            //});

            //modelBuilder.Entity<Movimiento>(entity =>
            //{
            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.CuentaId).HasColumnName("cuentaId");

            //    entity.Property(e => e.Saldo)
            //        .HasColumnType("decimal(18, 0)")
            //        .HasColumnName("saldo");

            //    entity.Property(e => e.TipoMovimiento).HasColumnName("tipoMovimiento");

            //    entity.Property(e => e.Valor)
            //        .HasColumnType("decimal(18, 0)")
            //        .HasColumnName("valor");

            //    entity.HasOne(d => d.Cuenta)
            //        .WithMany(p => p.Movimientos)
            //        .HasForeignKey(d => d.CuentaId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Movimientos_Cuenta");

            //    entity.HasOne(d => d.TipoMovimientoNavigation)
            //        .WithMany(p => p.Movimientos)
            //        .HasForeignKey(d => d.TipoMovimiento)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Movimientos_Configuracion");
            //});

            //modelBuilder.Entity<Persona>(entity =>
            //{
            //    entity.ToTable("Persona");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.Direccion)
            //        .HasMaxLength(150)
            //        .IsUnicode(false)
            //        .HasColumnName("direccion");

            //    entity.Property(e => e.Edad).HasColumnName("edad");

            //    entity.Property(e => e.GeneroId).HasColumnName("generoId");

            //    entity.Property(e => e.Identificicacion)
            //        .HasMaxLength(12)
            //        .IsUnicode(false)
            //        .HasColumnName("identificicacion");

            //    entity.Property(e => e.Nombre)
            //        .HasMaxLength(60)
            //        .IsUnicode(false)
            //        .HasColumnName("nombre");

            //    entity.Property(e => e.Telefono)
            //        .HasMaxLength(150)
            //        .IsUnicode(false)
            //        .HasColumnName("telefono");

            //    entity.HasOne(d => d.Genero)
            //        .WithMany(p => p.Personas)
            //        .HasForeignKey(d => d.GeneroId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Persona_Configuracion");
            //});

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
