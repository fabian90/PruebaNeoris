using System;
using System.Collections.Generic;

namespace TransaccionesBancarias.DTOs.Request
{
    public partial class ClienteDto
    {
     
        public long Id { get; set; }
        public string Contraseña { get; set; } = null!;
        public bool Estado { get; set; }
        public long PersonaId { get; set; }

        public virtual PersonaDto? Persona { get; set; }
    }
}
