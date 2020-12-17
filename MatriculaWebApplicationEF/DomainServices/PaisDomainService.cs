using MatriculaWebApplicationEF.Models;

namespace MatriculaWebApplicationEF.DomainServices
{
    public class PaisDomainService
    {
        public string RegistrarPais(Pais paisRequest)
        {
            var esNombreValido = paisRequest.Nombre == "";
            if (esNombreValido)
            {
                return "El nombre es inválido.";
            }

            return "Successful";
        }
    }
}
