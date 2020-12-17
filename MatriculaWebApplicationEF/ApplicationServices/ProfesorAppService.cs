using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.ApplicationServices
{
    public class ProfesorAppService
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly ProfesorDomainService _profesorDomainServices;

        public ProfesorAppService(UniversidadDataContext baseDatos, ProfesorDomainService profesorDomainService)
        {
            _baseDatos = baseDatos;
            _profesorDomainServices = profesorDomainService;
        }

        public async Task<string> RegistrarProfesor(Profesor profesorRequest)
        {
            var profesor = _baseDatos.Profesores.FirstOrDefault(q => q.Id == profesorRequest.Id);

            var profesorExiste = profesor != null;
            if (profesorExiste)
            {
                return "El profesor ya existe";
            }

            var pais = _baseDatos.Paises.FirstOrDefault(q => q.Id == profesorRequest.PaisId);
            var noExistePais = pais == null;
            if (noExistePais)
            {
                return "El pais no existe";
            }

            var materia = _baseDatos.Materias.FirstOrDefault(q => q.Id == profesorRequest.MateriaId);
            var noExisteMateria = materia == null;
            if (noExisteMateria)
            {
                return "La materia no existe";
            }

            var respuestaDomain = _profesorDomainServices.RegistrarProfesor(profesorRequest);

            var vieneConErrorEnElDomain = respuestaDomain != "Successful";
            if (vieneConErrorEnElDomain)
            {
                return respuestaDomain;
            }


            _baseDatos.Profesores.Add(profesorRequest);

            try
            {
                await _baseDatos.SaveChangesAsync();
                return null;
            }
            catch (Exception)
            {

                return "Oops! hubo un problema al guardar en la base de datos";
            }

        }
    }
}
