using MatriculaWebApplicationEF.Models;

namespace MatriculaWebApplicationEF.DomainServices
{
    public class ProfesorDomainService
    {
        public string RegistrarProfesor(Profesor profesorRequest)
        {
            var esSexoValid = profesorRequest.Sexo != "M" && profesorRequest.Sexo != "F";
            if (esSexoValid)
            {
                return "El sexo es inválido";
            }

            var esEdadValida = profesorRequest.Edad < 18;
            if (esEdadValida)
            {
                return "Edad es inválida, debe ser mayor a 18";
            }

            var esCorreoValido = profesorRequest.Correo == "";
            if (esCorreoValido)
            {
                return "El correo es inválido";
            }

            var esContrasenaValida = profesorRequest.Contrasena == "";
            if (esContrasenaValida)
            {
                return "La contrasena es inválida";
            }

            return "Successful";
        }
    }
}
