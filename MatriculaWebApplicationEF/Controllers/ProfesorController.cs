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
    public class ProfesorController : Controller
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly ProfesorAppService _profesorAppService;
        public ProfesorController(UniversidadDataContext context, ProfesorAppService profesorAppService)
        {
            _baseDatos = context;
            _profesorAppService = profesorAppService;

            if (_baseDatos.Profesores.Count() == 0)
            {
                _baseDatos.Profesores.Add(new Profesor { Nombre = "Josue", Edad = 25, Sexo = "M", Correo = "josue@gmail.com", Contrasena = "Contrasena123", IsActive = "true", PaisId = 1, MateriaId = 1 });
                _baseDatos.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesor>>> GetProfesores()
        {
            return await _baseDatos.Profesores.Include(q => q.Pais).Include(q => q.Materia).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profesor>> GetProfesor(int id)
        {
            var profesor = await _baseDatos.Profesores.Include(q => q.Pais).Include(q => q.Materia).FirstOrDefaultAsync(q => q.Id == id);

            if (profesor == null)
            {
                return NotFound();
            }

            return profesor;
        }

        [HttpPost]
        public async Task<ActionResult<Profesor>> PostProfesor(Profesor item)
        {
            var respuesta = await _profesorAppService.RegistrarProfesor(item);

            if (respuesta != null)
            {
                return BadRequest(respuesta);
            }

            return CreatedAtAction(nameof(GetProfesor), new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesor(int id)
        {
            var profesor = await _baseDatos.Profesores.FindAsync(id);

            if (profesor == null)
            {
                return NotFound();
            }

            _baseDatos.Profesores.Remove(profesor);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesor(int id, Profesor item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            Pais pais = await _baseDatos.Paises.FirstOrDefaultAsync(q => q.Id == item.PaisId);
            if (pais == null)
            {
                return NotFound("El pais no existe");
            }

            Materia materia = await _baseDatos.Materias.FirstOrDefaultAsync(q => q.Id == item.MateriaId);
            if (materia == null)
            {
                return NotFound("La materia no existe");
            }

            _baseDatos.Entry(item).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return Ok("success");

        }
    }
}
