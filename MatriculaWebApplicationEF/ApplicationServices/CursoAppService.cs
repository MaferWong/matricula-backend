using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.ApplicationServices
{
    public class CursoAppService
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly CursoDomainService _cursoDomainServices;

        public CursoAppService(UniversidadDataContext baseDatos, CursoDomainService cursoDomainService)
        {
            _baseDatos = baseDatos;
            _cursoDomainServices = cursoDomainService;
        }

        public async Task<string> RegistrarCurso(Curso cursoRequest)
        {
            var curso = _baseDatos.Cursos.FirstOrDefault(q => q.Id == cursoRequest.Id);

            var cursoExiste = curso != null;
            if (cursoExiste)
            {
                return "El curso ya existe";
            }

            var respuestaDomain = _cursoDomainServices.RegistrarCurso(cursoRequest);

            var vieneConErrorEnElDomain = respuestaDomain != "Successful";
            if (vieneConErrorEnElDomain)
            {
                return respuestaDomain;
            }

            _baseDatos.Cursos.Add(cursoRequest);

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