using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWebApplicationEF.ApplicationServices;
using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatriculaWebApplicationEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : Controller
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly CursoAppService _cursoAppService;
        public CursoController(UniversidadDataContext baseDeDatos, CursoAppService cursoAppService)
        {
            _baseDatos = baseDeDatos;
            _cursoAppService = cursoAppService;

            if (_baseDatos.Cursos.Count() == 0)
            {
                _baseDatos.Cursos.Add(new Curso { Nombre = "Informatica" });
                _baseDatos.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            return await _baseDatos.Cursos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            var curso = await _baseDatos.Cursos.FirstOrDefaultAsync(q => q.Id == id);

            if (curso == null)
            {
                return NotFound();
            }

            return curso;
        }

        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {
            var respuesta = await _cursoAppService.RegistrarCurso(curso);

            if (respuesta != null)
            {
                return BadRequest(respuesta);
            }

            return CreatedAtAction(nameof(GetCurso), new { id = curso.Id }, curso);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var curso = await _baseDatos.Cursos.FindAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            _baseDatos.Cursos.Remove(curso);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Curso curso)
        {
            if (id != curso.Id)
            {
                return BadRequest();
            }

            if (curso == null)
            {
                return NotFound("El curso no existe");
            }

            _baseDatos.Entry(curso).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }
    }
}