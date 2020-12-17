using MatriculaWebApplicationEF.Models;

namespace MatriculaWebApplicationEF.DomainServices
{
    public class CursoDomainService
    {
        public string RegistrarCurso(Curso cursoRequest)
        {
            var esNombreValido =cursoRequest.Nombre == "";
            if (esNombreValido)
            {
                return "El nombre es inválido.";
            }

            return "Successful";
        }
    }
}
