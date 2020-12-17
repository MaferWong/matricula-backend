using System.Collections.Generic;

namespace MatriculaWebApplicationEF.Models
{
    public class Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Estudiante> Estudiantes { get; set; }
        public List<Profesor> Profesores { get; set; }
    }
}
