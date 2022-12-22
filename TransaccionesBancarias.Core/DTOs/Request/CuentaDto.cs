using System;
using System.Collections.Generic;

namespace TransaccionesBancarias.DTOs.Request
{
    public partial class CuentaDto
    {
        public long Id { get; set; }
        public long NumeroCuenta { get; set; }
        public long TipoCuenta { get; set; }
        public long SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public long ClienteId { get; set; }

        public virtual ClienteDto? Cliente { get; set; }
        public virtual ConfiguracionDto? TipoCuentaNavigation { get; set; } 
    }
}
