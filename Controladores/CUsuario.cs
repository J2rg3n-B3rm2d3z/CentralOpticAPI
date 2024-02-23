using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/usuario")]
    
    public class CUsuario : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Super Administrador"))]
        public async Task<ActionResult<List<MUsuario>>> Get()
        {
            var funcion = new DUsuario();
            var lista = await funcion.MostrarUsuarios();
            foreach (var item in lista)
            {
                item.Clave = null;
            }
            return lista;
        }

        [HttpGet("{IdUsuario}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult<List<MUsuario>>> Get(string IdUsuario)
        {
            var funcion = new DUsuario();
            MUsuario usuario = new MUsuario();

            if(int.TryParse(IdUsuario, out int idUsuarioInt))
            {
                usuario.IdUsuario = idUsuarioInt;
                var lista = await funcion.MostrarUsuariosById(usuario);
                foreach (var item in lista)
                {
                    item.Clave = null;
                }
                return lista;
            }
            else
            {
                if(bool.TryParse(IdUsuario, out bool idUsuarioBool))
                {
                    usuario.Estado = idUsuarioBool;
                    var lista = await funcion.MostrarUsuariosActivos(usuario);
                    foreach (var item in lista)
                    {
                        item.Clave = null;
                    }
                    return lista;
                }
                else
                {
                    return BadRequest("El formato de peticion no es válido.");
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = ("Super Administrador"))]
        public async Task Post([FromBody] MUsuarioIngreso parametros)
        {
            var funcion = new DUsuario();
            await funcion.InsertarUsuario(parametros);
        }

        [HttpPut("{IdUsuario}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult> Put(int IdUsuario, [FromBody] MUsuarioIngreso parametros)
        {
            var funcion = new DUsuario();
            parametros.IdUsuario = IdUsuario;
            await funcion.EditarUsuario(parametros);
            if (parametros.Clave != null)
            {
                await funcion.EditarClaveUsuario(parametros);
            }
            return NoContent();
        }

        //[HttpDelete("{IdUsuario}")]
        //public async Task<ActionResult> Delete(int IdUsuario)
        //{
        //    var funcion = new DUsuario();
        //    var parametros = new MUsuario();
        //    parametros.IdUsuario = IdUsuario;
        //    await funcion.EliminarUsuario(parametros);
        //    return NoContent();
        //}
    }
}
