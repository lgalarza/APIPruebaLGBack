using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIPruebaLG.Contexto;
using APIPruebaLG.Data;
using System.Xml.Linq;

namespace APIPruebaLG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cargosController : ControllerBase
    {
        private readonly CrudData _data;

        public cargosController(CrudData repositorio)
        {
            _data = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        // GET: api/cargos
        [HttpGet]
        public async Task<ActionResult> Getcargos(short codigoDepartamento)
        {
            var response = await _data.Getcargos(codigoDepartamento);

            if (response == null)
                return Ok("No existen datos");
            else
                return Ok(response);
        }

        
    }
}
