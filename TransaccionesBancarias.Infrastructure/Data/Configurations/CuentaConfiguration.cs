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
    public class CuentaConfiguration : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> entity)
        {
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.ClienteId).HasColumnName("clienteId");

            entity.Property(e => e.Estado).HasColumnName("estado");

            entity.Property(e => e.NumeroCuenta).HasColumnName("numeroCuenta");

            entity.Property(e => e.SaldoInicial).HasColumnName("saldoInicial");

            entity.Property(e => e.TipoCuenta).HasColumnName("tipoCuenta");

            entity.HasOne(d => d.Cliente)
                .WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cuenta_Cliente");

            entity.HasOne(d => d.TipoCuentaNavigation)
                .WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.TipoCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cuenta_Configuracion");
        }
    }
}
