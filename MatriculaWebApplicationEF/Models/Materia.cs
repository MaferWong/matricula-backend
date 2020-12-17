using System.Collections.Generic;

namespace MatriculaWebApplicationEF.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Profesor> Profesores { get; set; }
    }
}
