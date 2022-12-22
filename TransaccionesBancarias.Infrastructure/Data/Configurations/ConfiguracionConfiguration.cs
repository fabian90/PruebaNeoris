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
    public class ConfiguracionConfiguration : IEntityTypeConfiguration<Configuracion>
    {
        public void Configure(EntityTypeBuilder<Configuracion> entity)
        {
            entity.ToTable("Configuracion");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");

            entity.Property(e => e.Estado).HasColumnName("estado");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.Property(e => e.Valor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("valor");
        }
    }
}
