using TechTalk.SpecFlow;
using FluentAssertions;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;

namespace MatriculaProject.Specs.Steps
{
    [Binding]
    public sealed class RegistroPaisStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Pais _pais = new Pais();
        private readonly PaisDomainService _paisDomainService = new PaisDomainService();
        private string _result;
        public RegistroPaisStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"el nombre del pais es ""(.*)""")]
        public void GivenElNombreDelPaisEs(string nombre)
        {
            _pais.Nombre = nombre;
        }

        [When(@"registrando el pais")]
        public void WhenRegistrandoElPais()
        {
            _result = _paisDomainService.RegistrarPais(_pais);
        }

        [Then(@"el registro del pais es ""(.*)""")]
        public void ThenElRegistroDelPaisEs(string result)
        {
            _result.Should().Be(result);
        }
    }
}