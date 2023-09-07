using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIPruebaLG.Contexto;
using APIPruebaLG.Models;
using APIPruebaLG.Data;

namespace APIPruebaLG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class departamentosController : ControllerBase
    {
        private readonly CrudData _data;

        public departamentosController(CrudData repositorio)
        {
            _data = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        [HttpGet]
        public async Task<ActionResult> GetDepartamentos()
        {
            var response = await _data.Getdepartamentos();

            if (response == null)
                return Ok("No existen datos");
            else
                return Ok(response);
        }

    }
}
