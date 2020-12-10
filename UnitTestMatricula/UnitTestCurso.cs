using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMatricula
{
    [TestClass]
    public class UnitTestCurso
    {
        [TestMethod]
        public void ValidarNombreCurso()
        {
            CursoDomainService estudianteDomainService = new CursoDomainService();
            Curso curso = new Curso();
            curso.Nombre = "";

            var respuesta = estudianteDomainService.RegistrarCurso(curso);

            Assert.AreEqual("El nombre es inválido.", respuesta);
        }
    }
}
