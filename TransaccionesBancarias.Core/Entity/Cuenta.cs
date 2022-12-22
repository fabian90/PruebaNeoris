using System;
using System.Collections.Generic;
using TransaccionesBancarias.Commons.Repository.Entities;

namespace TransaccionesBancarias.Core.Entity
{
    public partial class Cuenta : BaseEntity
    {
        public Cuenta()
        {
            Movimientos = new HashSet<Movimiento>();
        }

        public long Id { get; set; }
        public long NumeroCuenta { get; set; }
        public long TipoCuenta { get; set; }
        public long SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public long ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; } = null!;
        public virtual Configuracion TipoCuentaNavigation { get; set; } = null!;
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
