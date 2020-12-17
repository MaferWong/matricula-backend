using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.ApplicationServices
{
    public class MateriaAppService
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly MateriaDomainService _materiaDomainServices;

        public MateriaAppService(UniversidadDataContext baseDatos, MateriaDomainService materiaDomainService)
        {
            _baseDatos = baseDatos;
            _materiaDomainServices = materiaDomainService;
        }

        public async Task<string> RegistrarMateria(Materia materiaRequest)
        {
            var materia = _baseDatos.Materias.FirstOrDefault(q => q.Id == materiaRequest.Id);

            var materiaExiste = materia != null;
            if (materiaExiste)
            {
                return "La materia ya existe";
            }

            var curso = _baseDatos.Cursos.FirstOrDefault(q => q.Id == materiaRequest.CursoId);
            var noExisteCurso = curso == null;
            if (noExisteCurso)
            {
                return "El curso no existe";
            }

            var respuestaDomain = _materiaDomainServices.RegistrarMateria(materiaRequest);

            var vieneConErrorEnElDomain = respuestaDomain != "Successful";
            if (vieneConErrorEnElDomain)
            {
                return respuestaDomain;
            }


            _baseDatos.Materias.Add(materiaRequest);
            
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
