using System;
using System.Collections.Generic;
using TransaccionesBancarias.Commons.Repository.Entities;

namespace TransaccionesBancarias.Core.Entity
{
    public partial class Configuracion : BaseEntity
    {
        public Configuracion()
        {
            Cuenta = new HashSet<Cuenta>();
            Movimientos = new HashSet<Movimiento>();
            Personas = new HashSet<Persona>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Valor { get; set; } = null!;
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Cuenta> Cuenta { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }
    }
}
