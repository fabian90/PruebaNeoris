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
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> entity)
        {
            entity.ToTable("Cliente");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Contraseña)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contraseña");

            entity.Property(e => e.Estado).HasColumnName("estado");

            entity.Property(e => e.PersonaId).HasColumnName("personaId");

            entity.HasOne(d => d.Persona)
                .WithMany(p => p.Clientes)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_Persona");
        }
    }
}
