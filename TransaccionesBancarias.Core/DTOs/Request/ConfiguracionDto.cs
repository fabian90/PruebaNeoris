using System;
using System.Collections.Generic;

namespace TransaccionesBancarias.DTOs.Request
{
    public partial class ConfiguracionDto
    {

        public long Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Valor { get; set; } = null!;
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
    
    }
}
