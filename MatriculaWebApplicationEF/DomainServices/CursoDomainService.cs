using MatriculaWebApplicationEF.Models;

namespace MatriculaWebApplicationEF.DomainServices
{
    public class CursoDomainService
    {
        public string RegistrarCurso(Curso cursoRequest)
        {
            var esNombreValid =cursoRequest.Nombre == "";
            if (esNombreValid)
            {
                return "El nombre es inválido.";
            }

            return null;
        }
    }
}
