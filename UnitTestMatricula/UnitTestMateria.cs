using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMatricula
{
    [TestClass]
    public class UnitTestMateria
    {
        [TestMethod]
        public void ValidarCodigoMateria()
        {
            MateriaDomainService materiaDomainService = new MateriaDomainService();
            Materia materia = new Materia();
            materia.Codigo = "";

            var respuesta = materiaDomainService.RegistrarMateria(materia);

            Assert.AreEqual("El codigo es inválido.", respuesta);
        }

        [TestMethod]
        public void ValidarNombreMateria()
        {
            MateriaDomainService materiaDomainService = new MateriaDomainService();
            Materia materia = new Materia();
            materia.Nombre = "";

            var respuesta = materiaDomainService.RegistrarMateria(materia);

            Assert.AreEqual("El nombre es inválido.", respuesta);
        }
    }
}
