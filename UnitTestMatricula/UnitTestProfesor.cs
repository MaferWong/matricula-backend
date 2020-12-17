using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMatricula
{
    [TestClass]
    public class UnitTestProfesor
    {
        [TestMethod]
        public void ValidarEdadProfesorMenorA18()
        {
            ProfesorDomainService profesorDomainService = new ProfesorDomainService();
            Profesor profesor = new Profesor();
            profesor.Nombre = "Test Vanguardia";
            profesor.Edad = 14;
            profesor.Sexo = "M";

            var respuesta = profesorDomainService.RegistrarProfesor(profesor);

            Assert.AreEqual("Edad es inválida, debe ser mayor a 18", respuesta);
        }

        [TestMethod]
        public void ValidarEdadProfesorMayorA18()
        {
            ProfesorDomainService profesorDomainService = new ProfesorDomainService();
            Profesor profesor = new Profesor();
            profesor.Nombre = "Test Vanguardia";
            profesor.Edad = 20;
            profesor.Sexo = "M";

            var respuesta = profesorDomainService.RegistrarProfesor(profesor);

            Assert.AreEqual("Successful", respuesta);
        }

        [TestMethod]
        public void ValidarCorreo()
        {
            ProfesorDomainService profesorDomainService = new ProfesorDomainService();
            Profesor profesor = new Profesor();
            profesor.Nombre = "Test Vanguardia";
            profesor.Edad = 19;
            profesor.Sexo = "M";
            profesor.Correo = "";

            var respuesta = profesorDomainService.RegistrarProfesor(profesor);

            Assert.AreEqual("El correo es inválido", respuesta);
        }

        [TestMethod]
        public void ValidarContrasena()
        {
            ProfesorDomainService profesorDomainService = new ProfesorDomainService();
            Profesor profesor = new Profesor();
            profesor.Nombre = "Test Vanguardia";
            profesor.Edad = 19;
            profesor.Sexo = "M";
            profesor.Contrasena = "";

            var respuesta = profesorDomainService.RegistrarProfesor(profesor);

            Assert.AreEqual("La contrasena es inválida", respuesta);
        }
    }
}
