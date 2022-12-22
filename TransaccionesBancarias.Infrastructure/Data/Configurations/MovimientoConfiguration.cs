using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransaccionesBancarias.Core.Entity;

namespace TransaccionesBancarias.Infrastructure.Data.Configurations
{
    public class MovimientoConfiguration : IEntityTypeConfiguration<Movimiento>
    {
        public void Configure(EntityTypeBuilder<Movimiento> entity)
        {
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.CuentaId).HasColumnName("cuentaId");

            entity.Property(e => e.Saldo)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("saldo");

            entity.Property(e => e.TipoMovimiento).HasColumnName("tipoMovimiento");

            entity.Property(e => e.Valor)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("valor");

            entity.HasOne(d => d.Cuenta)
                .WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.CuentaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movimientos_Cuenta");

            entity.HasOne(d => d.TipoMovimientoNavigation)
                .WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.TipoMovimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movimientos_Configuracion");

            entity.Property(e => e.Fecha)
               .HasColumnName("fecha")
               .HasColumnType("date");
        }
    }
}
