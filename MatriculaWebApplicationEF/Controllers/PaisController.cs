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
    public class PaisController : Controller
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly PaisAppService _paisAppService;
        public PaisController(UniversidadDataContext baseDeDatos, PaisAppService paisAppService)
        {
            _baseDatos = baseDeDatos;
            _paisAppService = paisAppService;

            if (_baseDatos.Paises.Count() == 0)
            {
                _baseDatos.Paises.Add(new Pais { Nombre = "Honduras" });
                _baseDatos.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pais>>> GetPais()
        {
            return await _baseDatos.Paises.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pais>> GetPais(int id)
        {
            var pais = await _baseDatos.Paises.FirstOrDefaultAsync(q => q.Id == id);

            if (pais == null)
            {
                return NotFound();
            }

            return pais;
        }

        [HttpPost]
        public async Task<ActionResult<Pais>> PostPais(Pais pais)
        {
            var respuesta = await _paisAppService.RegistrarPais(pais);

            if (respuesta != null)
            {
                return BadRequest(respuesta);
            }

            return CreatedAtAction(nameof(GetPais), new { id = pais.Id }, pais);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePais(int id)
        {
            var pais = await _baseDatos.Paises.FindAsync(id);

            if (pais == null)
            {
                return NotFound();
            }

            _baseDatos.Paises.Remove(pais);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPais(int id, Pais pais)
        {
            if (id != pais.Id)
            {
                return BadRequest();
            }

            if (pais == null)
            {
                return NotFound("El pais no existe");
            }

            _baseDatos.Entry(pais).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }
    }
}
