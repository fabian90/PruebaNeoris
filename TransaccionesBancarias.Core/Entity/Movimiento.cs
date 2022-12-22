using System;
using System.Collections.Generic;
using TransaccionesBancarias.Commons.Repository.Entities;

namespace TransaccionesBancarias.Core.Entity
{
    public partial class Movimiento : BaseEntity
    {
        public long Id { get; set; }
        public long TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public long CuentaId { get; set; }
        public DateTime Fecha { get; set; }
        public virtual Cuenta Cuenta { get; set; } = null!;
        public virtual Configuracion TipoMovimientoNavigation { get; set; } = null!;
    }
}
