using TechTalk.SpecFlow;
using FluentAssertions;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;

namespace MatriculaProject.Specs.Steps
{
    [Binding]
    public sealed class MatriculaStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Estudiante _estudiante = new Estudiante();
        private readonly EstudianteDomainService _estudianteDomainService = new EstudianteDomainService();
        private string _result;
        public MatriculaStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"el nombre del estudiante es ""(.*)""")]
        public void GivenElNombreDelEstudianteEs(string nombre)
        {
            _estudiante.Nombre = nombre;
        }

        [Given(@"la edad del estudiante is (.*)")]
        public void GivenLaEdadIs(int edad)
        {
            _estudiante.Edad = edad;
        }

        [Given(@"el sexo del estudiante es ""(.*)""")]
        public void GivenElSexoEs(string sexo)
        {
            _estudiante.Sexo = sexo;
        }

        [Given(@"el correo del estudiante es ""(.*)""")]
        public void GivenElCorreoEs(string correo)
        {
            _estudiante.Correo = correo;
        }

        [Given(@"la contrasena del estudiante es ""(.*)""")]
        public void GivenLaContrasenaEs(string contrasena)
        {
            _estudiante.Contrasena = contrasena;
        }

        [Given(@"el usuario del estudiante isActive es ""(.*)""")]
        public void GivenElUsuarioIsActiveEs(string estado)
        {
            _estudiante.IsActive = estado;
        }

        [Given(@"el paisId del estudiante es (.*)")]
        public void GivenElPaisIdEs(int paisId)
        {
            _estudiante.PaisId = paisId;
        }

        [Given(@"el cursoId del estudiante es (.*)")]
        public void GivenElCursoIdEs(int cursoId)
        {
            _estudiante.CursoId = cursoId;
        }

        [When(@"matriculando el estudiante")]
        public void WhenMatriculandoElEstudiante()
        {
            _result = _estudianteDomainService.RegistrarEstudiante(_estudiante);
        }

        [Then(@"la matricula es ""(.*)""")]
        public void ThenLaMatriculaEs(string result)
        {
            _result.Should().Be(result);
        }
    }
}
