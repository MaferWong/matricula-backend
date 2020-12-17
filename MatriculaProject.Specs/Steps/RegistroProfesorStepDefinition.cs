using TechTalk.SpecFlow;
using FluentAssertions;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;

namespace MatriculaProject.Specs.Steps
{
    [Binding]
    public sealed class RegistroProfesorStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Profesor _profesor = new Profesor();
        private readonly ProfesorDomainService _profesorDomainService = new ProfesorDomainService();
        private string _result;

        public RegistroProfesorStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"el nombre del profesor es ""(.*)""")]
        public void GivenElNombreDelProfesorEs(string nombre)
        {
            _profesor.Nombre = nombre;
        }

        [Given(@"la edad del profesor is (.*)")]
        public void GivenLaEdadIs(int edad)
        {
            _profesor.Edad = edad;
        }

        [Given(@"el sexo del profesor es ""(.*)""")]
        public void GivenElSexoDelProfesorEs(string sexo)
        {
            _profesor.Sexo = sexo;
        }

        [Given(@"el correo del profesor es ""(.*)""")]
        public void GivenElCorreoDelProfesorEs(string correo)
        {
            _profesor.Correo = correo;
        }

        [Given(@"la contrasena del profesor es ""(.*)""")]
        public void GivenLaContrasenaDelProfesorEs(string contrasena)
        {
            _profesor.Contrasena = contrasena;
        }

        [Given(@"el usuario del profesor isActive es ""(.*)""")]
        public void GivenElUsuarioDelProfesorIsActiveEs(string estado)
        {
            _profesor.IsActive = estado;
        }

        [Given(@"el paisId del profesor es (.*)")]
        public void GivenElPaisIdDelProfesorEs(int paisId)
        {
            _profesor.PaisId = paisId;
        }

        [Given(@"el materiaId del profesor es (.*)")]
        public void GivenElMateriaIdDelProfesorEs(int materiaId)
        {
            _profesor.MateriaId = materiaId;
        }

        [When(@"registrando el profesor")]
        public void WhenRegistrandoElProfesor()
        {
            _result = _profesorDomainService.RegistrarProfesor(_profesor);
        }

        [Then(@"el registro es ""(.*)""")]
        public void ThenElRegistroEs(string result)
        {
            _result.Should().Be(result);
        }
    }
}
