using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMatricula
{
    [TestClass]
    public class UnitTestPais
    {
        [TestMethod]
        public void ValidarNombrePais()
        {
            PaisDomainService paisDomainService = new PaisDomainService();
            Pais pais = new Pais();
            pais.Nombre = "";

            var respuesta = paisDomainService.RegistrarPais(pais);

            Assert.AreEqual("El nombre es inválido.", respuesta);
        }
    }
}
