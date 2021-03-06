﻿using System;
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
    public class EstudianteController : ControllerBase
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly EstudianteAppService _estudianteAppService;
        public EstudianteController(UniversidadDataContext context, EstudianteAppService estudianteAppService)
        {
            _baseDatos = context;
            _estudianteAppService = estudianteAppService;

            if (_baseDatos.Estudiantes.Count() == 0)
            {
                _baseDatos.Estudiantes.Add(new Estudiante { Nombre = "Fernanda", Edad = 19, Sexo = "F", Correo = "mafer@gmail.com", Contrasena = "Contrasena123", IsActive = "true", PaisId = 1, CursoId = 1 });
                _baseDatos.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> GetEstudiantes()
        {
            return await _baseDatos.Estudiantes.Include(q => q.Pais).Include(q => q.Curso).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
        {
            var estudiante = await _baseDatos.Estudiantes.Include(q => q.Pais).Include(q => q.Curso).FirstOrDefaultAsync(q => q.Id == id);

            if (estudiante == null)
            {
                return NotFound();
            }

            return estudiante;
        }

        [HttpPost]
        public async Task<ActionResult<Estudiante>> PostEstudiante(Estudiante item)
        {
            var respuesta = await _estudianteAppService.RegistrarEstudiante(item);

            if (respuesta != null)
            {
                return BadRequest(respuesta);
            }

            return CreatedAtAction(nameof(GetEstudiante), new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var estudiante = await _baseDatos.Estudiantes.FindAsync(id);

            if (estudiante == null)
            {
                return NotFound();
            }

            _baseDatos.Estudiantes.Remove(estudiante);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiante(int id, Estudiante item)
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

            Curso curso = await _baseDatos.Cursos.FirstOrDefaultAsync(q => q.Id == item.CursoId);
            if (curso == null)
            {
                return NotFound("El curso no existe");
            }

            _baseDatos.Entry(item).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return Ok("success");

        }
    }
}