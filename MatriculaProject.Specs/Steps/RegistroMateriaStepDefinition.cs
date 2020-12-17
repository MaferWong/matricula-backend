using TechTalk.SpecFlow;
using FluentAssertions;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;

namespace MatriculaProject.Specs.Steps
{
    [Binding]
    public sealed class RegistroMateriaStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Materia _materia = new Materia();
        private readonly MateriaDomainService _materiaDomainService = new MateriaDomainService();
        private string _result;
        public RegistroMateriaStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"el codigo de materia es ""(.*)""")]
        public void GivenElCodigoDeMateriaEs(string codigo)
        {
            _materia.Codigo = codigo;
        }

        [Given(@"el nombre de materia es ""(.*)""")]
        public void GivenElNombreDeMateriaEs(string nombre)
        {
            _materia.Nombre = nombre;
        }

        [Given(@"el cursoId de la materia es (.*)")]
        public void GivenElCursoIdDeLaMateriaEs(int cursoId)
        {
            _materia.CursoId = cursoId;
        }

        [When(@"registrando la materia")]
        public void WhenRegistrandoLaMateria()
        {
            _result = _materiaDomainService.RegistrarMateria(_materia);
        }

        [Then(@"el registro de materia es ""(.*)""")]
        public void ThenElRegistroDeMateriaEs(string result)
        {
            _result.Should().Be(result);
        }
    }
}
