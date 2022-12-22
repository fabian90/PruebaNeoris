using System;
using System.Collections.Generic;
using TransaccionesBancarias.Commons.Repository.Entities;

namespace TransaccionesBancarias.Core.Entity
{
    public partial class Cliente : BaseEntity
    {
        public Cliente()
        {
            Cuenta = new HashSet<Cuenta>();
        }

        public long Id { get; set; }
        public string Contraseña { get; set; } = null!;
        public bool Estado { get; set; }
        public long PersonaId { get; set; }

        public virtual Persona Persona { get; set; } = null!;
        public virtual ICollection<Cuenta> Cuenta { get; set; }
    }
}
