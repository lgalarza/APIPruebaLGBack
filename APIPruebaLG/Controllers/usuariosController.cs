using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIPruebaLG.Contexto;
using APIPruebaLGDTO;
using System.Xml.Linq;
using APIPruebaLG.Data;
using APIPruebaLG.Models;

namespace APIPruebaLG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuariosController : ControllerBase
    {
        private readonly CrudData _data;

        public usuariosController(CrudData repositorio)
        {
            _data = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        [HttpPost("Getusuarios")]
        public async Task<ActionResult> Getusuarios(usuariosDTO filtro)
        {
            var response = await _data.GetAllusuarios(filtro);

            if (response == null)
                return Ok("No existen datos");
            else
                return Ok(response);
        }

        // POST: api/usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Postusuarios")]
        public async Task<ActionResult<usuariosDTO>> Postusuarios(usuariosDTO usuario)
        {
            var response = await _data.Postusuarios(usuario);

            return CreatedAtAction("Getusuarios", new { id = usuario.codigoUsuario }, usuario);
        }

        // UPDATE: api/usuarios/5
        [HttpPut("Putusuarios")]
        public async Task<IActionResult> Putusuarios(usuariosDTO usuario)
        {
            var response = await _data.Putusuarios(usuario);

            return NoContent();
        }


        // DELETE: api/usuarios/5
        [HttpDelete("Deleteusuarios")]
        public async Task<IActionResult> Deleteusuarios(usuariosDTO usuario)
        {
            var response = await _data.Deleteusuarios(usuario);

            return NoContent();
        }

       
    }
}
