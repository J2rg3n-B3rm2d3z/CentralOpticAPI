using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/correocliente")]
    public class CCorreoCliente : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult<List<MCorreoCliente>>> Get()
        {
            var funcion = new DCorreoCliente();
            var lista = await funcion.MostrarCorreoClientes();
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task Post([FromBody] MCorreoCliente parametros)
        {
            var funcion = new DCorreoCliente();
            await funcion.InsertarCorreoCliente(parametros);
        }

        [HttpPut("{IdCorreoCliente}")]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult> Put(int IdCorreoCliente, [FromBody] MCorreoCliente parametros)
        {
            var funcion = new DCorreoCliente();
            parametros.IdCorreoCliente = IdCorreoCliente;
            await funcion.EditarCorreoCliente(parametros);
            return NoContent();
        }

        [HttpDelete("{IdCorreoCliente}")]
        [Authorize(Roles = ("Administrador"))]
        public async Task<ActionResult> Delete(int IdCorreoCliente)
        {
            var funcion = new DCorreoCliente();
            var parametros = new MCorreoCliente();
            parametros.IdCorreoCliente = IdCorreoCliente;
            await funcion.EliminarCorreoCliente(parametros);
            return NoContent();

        }
    }
}
