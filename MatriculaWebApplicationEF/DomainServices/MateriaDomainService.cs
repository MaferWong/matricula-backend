using MatriculaWebApplicationEF.Models;

namespace MatriculaWebApplicationEF.DomainServices
{
    public class MateriaDomainService
    {
        public string RegistrarMateria(Materia materiaRequest)
        {
            var esCodigoValido = materiaRequest.Codigo == "";
            if (esCodigoValido)
            {
                return "El codigo es inválido.";
            }

            var esNombreValid = materiaRequest.Nombre == "";
            if (esNombreValid)
            {
                return "El nombre es inválido.";
            }

            return "Successful";
        }
    }
}
