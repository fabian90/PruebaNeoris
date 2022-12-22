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
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> entity)
        {
            entity.ToTable("Persona");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("direccion");

            entity.Property(e => e.Edad).HasColumnName("edad");

            entity.Property(e => e.GeneroId).HasColumnName("generoId");

            entity.Property(e => e.Identificacion)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("identificacion");

            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.Property(e => e.Telefono)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.Genero)
                .WithMany(p => p.Personas)
                .HasForeignKey(d => d.GeneroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_Configuracion");
        }
    }
}
