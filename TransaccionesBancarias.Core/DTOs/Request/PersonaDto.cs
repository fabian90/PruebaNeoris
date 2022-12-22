using System;
using System.Collections.Generic;

namespace TransaccionesBancarias.DTOs.Request
{
    public partial class PersonaDto
    {
       
        public long Id { get; set; }
        public string Nombre { get; set; } = null!;
        public long GeneroId { get; set; }
        public int Edad { get; set; }
        public string Identificacion{ get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string? Telefono { get; set; }

        public virtual ConfiguracionDto? Genero { get; set; }
    }
}
