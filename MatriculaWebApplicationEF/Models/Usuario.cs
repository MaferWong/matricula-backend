using System.Collections.Generic;

namespace MatriculaWebApplicationEF.Models
{
    public class Usuario
    {
        public string UsuarioId { get; set; }
        public string Contrasena { get; set; }
        public bool EstaActivo { get; set; }
    }
}
