using Microsoft.EntityFrameworkCore;
using APIPruebaLG.Contexto;
using APIPruebaLG.Models;
using APIPruebaLGDTO;
using Microsoft.AspNetCore.Mvc;

namespace APIPruebaLG.Data
{
    public class CrudData
    {
        private readonly PruebaLGDBContext _context;

        public CrudData(PruebaLGDBContext context)
        { 
            _context = context;
        }

        public async Task<List<departamentoDTO>> Getdepartamentos()
        {
            List<departamentoDTO> listaRetorno = new List<departamentoDTO>();
            foreach(var item in await _context.departamentos.ToListAsync())
            {
                departamentoDTO itemDepartamento = new departamentoDTO();
                itemDepartamento.codigoDepartamento = item.codigoDepartamento;
                itemDepartamento.nombreDepartamento = item.nombreDepartamento;
                listaRetorno.Add(itemDepartamento);
            }
            return listaRetorno;
        }

        public async Task<List<cargosDTO>> Getcargos(short codigoDepartamento)
        {
            List<cargosDTO> listaRetorno = new List<cargosDTO>();
            foreach (var item in await _context.cargos.AsQueryable().Where(c => c.codigoDepartamento == codigoDepartamento).ToListAsync())
            {
                cargosDTO itemCargos = new cargosDTO();
                itemCargos.codigoCargo = item.codigoCargo;
                itemCargos.descripcionCargo = item.descripcionCargo;
                listaRetorno.Add(itemCargos);
            }

            return listaRetorno.ToList();
        }

        public async Task<List<usuariosDTO>> GetAllusuarios(usuariosDTO filtro)
        {
            List<usuariosDTO> listaRetorno = new List<usuariosDTO>();

            if (filtro.codigoDepartamento == 0 && filtro.codigoCargo == 0)
            {
                foreach (var item in await _context.usuarios.ToListAsync())
                {
                    usuariosDTO itemUsuario = new usuariosDTO();
                    itemUsuario.codigoUsuario = item.codigoUsuario;
                    itemUsuario.codigoDepartamento = item.codigoDepartamento;
                    itemUsuario.nombreDepartamento = _context.departamentos.AsQueryable().Where(c => c.codigoDepartamento == item.codigoDepartamento).FirstOrDefault().nombreDepartamento;
                    itemUsuario.codigoCargo = item.codigoCargo;
                    itemUsuario.descripcionCargo = _context.cargos.AsQueryable().Where(c => c.codigoCargo == item.codigoCargo).FirstOrDefault().descripcionCargo;
                    itemUsuario.nombres = item.nombres;
                    itemUsuario.apellidos = item.apellidos;
                    itemUsuario.email = item.email;
                    listaRetorno.Add(itemUsuario);
                }
            }

            if (filtro.codigoDepartamento != 0 && filtro.codigoCargo != 0)
            {
                foreach (var item in await _context.usuarios.AsQueryable().Where(c => c.codigoDepartamento == filtro.codigoDepartamento && c.codigoCargo == filtro.codigoCargo).ToListAsync())
                {
                    usuariosDTO itemUsuario = new usuariosDTO();
                    itemUsuario.codigoUsuario = item.codigoUsuario;
                    itemUsuario.codigoDepartamento = item.codigoDepartamento;
                    itemUsuario.nombreDepartamento = _context.departamentos.AsQueryable().Where(c => c.codigoDepartamento == item.codigoDepartamento).FirstOrDefault().nombreDepartamento;
                    itemUsuario.codigoCargo = item.codigoCargo;
                    itemUsuario.descripcionCargo = _context.cargos.AsQueryable().Where(c => c.codigoCargo == item.codigoCargo).FirstOrDefault().descripcionCargo;
                    itemUsuario.nombres = item.nombres;
                    itemUsuario.apellidos = item.apellidos;
                    itemUsuario.email = item.email;
                    listaRetorno.Add(itemUsuario);
                }
            }

            if (filtro.codigoDepartamento != 0 && filtro.codigoCargo == 0)
            {
                foreach (var item in await _context.usuarios.AsQueryable().Where(c => c.codigoDepartamento == filtro.codigoDepartamento).ToListAsync())
                {
                    usuariosDTO itemUsuario = new usuariosDTO();
                    itemUsuario.codigoUsuario = item.codigoUsuario;
                    itemUsuario.codigoDepartamento = item.codigoDepartamento;
                    itemUsuario.nombreDepartamento = _context.departamentos.AsQueryable().Where(c => c.codigoDepartamento == item.codigoDepartamento).FirstOrDefault().nombreDepartamento;
                    itemUsuario.codigoCargo = item.codigoCargo;
                    itemUsuario.descripcionCargo = _context.cargos.AsQueryable().Where(c => c.codigoCargo == item.codigoCargo).FirstOrDefault().descripcionCargo;
                    itemUsuario.nombres = item.nombres;
                    itemUsuario.apellidos = item.apellidos;
                    itemUsuario.email = item.email;
                    listaRetorno.Add(itemUsuario);
                }
            }

            if (filtro.codigoDepartamento == 0 && filtro.codigoCargo != 0)
            {
                foreach (var item in await _context.usuarios.AsQueryable().Where(c => c.codigoCargo == filtro.codigoCargo).ToListAsync())
                {
                    usuariosDTO itemUsuario = new usuariosDTO();
                    itemUsuario.codigoUsuario = item.codigoUsuario;
                    itemUsuario.codigoDepartamento = item.codigoDepartamento;
                    itemUsuario.nombreDepartamento = _context.departamentos.AsQueryable().Where(c => c.codigoDepartamento == item.codigoDepartamento).FirstOrDefault().nombreDepartamento;
                    itemUsuario.codigoCargo = item.codigoCargo;
                    itemUsuario.descripcionCargo = _context.cargos.AsQueryable().Where(c => c.codigoCargo == item.codigoCargo).FirstOrDefault().descripcionCargo;
                    itemUsuario.nombres = item.nombres;
                    itemUsuario.apellidos = item.apellidos;
                    itemUsuario.email = item.email;
                    listaRetorno.Add(itemUsuario);
                }
            }

            return listaRetorno;
        }

        public async Task<ActionResult<usuariosDTO>> Postusuarios(usuariosDTO usuario)
        {
            if (_context.usuarios == null)
            {
                return null;
            }
            usuarios nuevoUsuario = new usuarios();
            nuevoUsuario.codigoUsuario = usuario.codigoUsuario;
            nuevoUsuario.codigoDepartamento = usuario.codigoDepartamento;
            nuevoUsuario.codigoCargo = usuario.codigoCargo;
            nuevoUsuario.nombres = usuario.nombres;
            nuevoUsuario.apellidos = usuario.apellidos;
            nuevoUsuario.email = usuario.email;
            nuevoUsuario.estadoUsuario = true;
            nuevoUsuario.usuarioCreacion = "lgalarza";
            nuevoUsuario.fechaCreacion = DateTime.Now;
            nuevoUsuario.equipoCreacion = "PC1";

            _context.usuarios.Add(nuevoUsuario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (usuariosExists(nuevoUsuario.codigoUsuario))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return usuario;
        }
        private bool usuariosExists(string id)
        {
            return (_context.usuarios?.Any(e => e.codigoUsuario == id)).GetValueOrDefault();
        }

        public async Task<ActionResult<bool>> Deleteusuarios(usuariosDTO usuario)
        {
            if (_context.usuarios == null)
            {
                return false;
            }
            var usuarios = await _context.usuarios.FindAsync(usuario.codigoUsuario);
            if (usuarios == null)
            {
                return false;
            }

            _context.usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ActionResult<int>> Putusuarios(usuariosDTO usuario)
        {
            usuarios usuarioBase = new usuarios();
            usuarioBase = _context.usuarios.Where(u=>u.codigoUsuario == usuario.codigoUsuario).FirstOrDefault();


            if (usuario.codigoUsuario != usuarioBase.codigoUsuario)
            {
                return 0;
            }

            usuarioBase.estadoUsuario = (bool)usuario.estadoUsuario;

            _context.Entry(usuarioBase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!usuariosExists(usuario.codigoUsuario))
                {
                    return 0;
                }
                else
                {
                    throw;
                }
            }

            return 1;
        }
    }
}
