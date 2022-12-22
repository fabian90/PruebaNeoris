using System;
using System.Collections.Generic;

namespace TransaccionesBancarias.DTOs.Request
{
    public partial class MovimientoDto
    {
        public long Id { get; set; }
        public long TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public DateTime Fecha { get; set; }
        public long CuentaId { get; set; }
        public decimal SaldoDisponible
        {
            get { return Saldo - Valor; }
        }
        public virtual CuentaDto? Cuenta { get; set; }
        public virtual ConfiguracionDto? TipoMovimientoNavigation { get; set; }
    }
}
