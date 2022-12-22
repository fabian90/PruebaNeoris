using System;
using System.Collections.Generic;
using TransaccionesBancarias.Commons.Repository.Entities;

namespace TransaccionesBancarias.Core.Entity
{
    public partial class Persona : BaseEntity
    {
        public Persona()
        {
            Clientes = new HashSet<Cliente>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; } = null!;
        public long GeneroId { get; set; }
        public int Edad { get; set; }
        public string Identificacion{ get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string? Telefono { get; set; }

        public virtual Configuracion Genero { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
