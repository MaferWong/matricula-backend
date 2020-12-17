using MatriculaWebApplicationEF.ApplicationServices;
using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly UsuarioAppService _usuarioAppService;
        public UsuarioController(UniversidadDataContext context, UsuarioAppService usuarioAppService)
        {
            _baseDatos = context;
            _usuarioAppService = usuarioAppService;

            if (_baseDatos.Usuarios.Count() == 0)
            {
                _baseDatos.Usuarios.Add(new Usuario { UsuarioId = "jaleman", Contrasena = "123", EstaActivo = true });
                _baseDatos.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _baseDatos.Usuarios.ToListAsync();
        }

        [HttpGet("{usuarioId}/{contrasenia}")]
        public async Task<ActionResult<Usuario>> GetUsuario(string usuarioId, string contrasenia)
        {
            var response = await _usuarioAppService.TieneAccesoUsuario(usuarioId, contrasenia);

            if (response != "success")
            {
                return BadRequest(response);

            }
            return Ok("success");
        }
    }
}