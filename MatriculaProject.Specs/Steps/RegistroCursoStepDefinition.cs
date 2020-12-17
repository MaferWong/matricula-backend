using TechTalk.SpecFlow;
using FluentAssertions;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;

namespace MatriculaProject.Specs.Steps
{
    [Binding]
    public sealed class RegistroCursoStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Curso _curso = new Curso();
        private readonly CursoDomainService _cursoDomainService = new CursoDomainService();
        private string _result;
        public RegistroCursoStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"el nombre del curso es ""(.*)""")]
        public void GivenElNombreDelCursoEs(string nombre)
        {
            _curso.Nombre = nombre;
        }

        [When(@"registrando el curso")]
        public void WhenRegistrandoElCurso()
        {
            _result = _cursoDomainService.RegistrarCurso(_curso);
        }

        [Then(@"el registro del curso es ""(.*)""")]
        public void ThenElRegistroDelCursoEs(string result)
        {
            _result.Should().Be(result);
        }
    }
}
