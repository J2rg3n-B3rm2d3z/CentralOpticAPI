using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/correoempleado")]
    [Authorize(Roles = ("Administrador"))]
    public class CEmpleadoCorreoEmpleado :Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MEmpleadoCorreoEmpleado>>> Get()
        {
            var funcion = new DEmpleadoCorreoEmpleado();
            var lista = await funcion.MostrarCorreoEmpleado();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] MEmpleadoCorreoEmpleado parametros)
        {
            var funcion = new DEmpleadoCorreoEmpleado();
            await funcion.InsertarCorreoEmpleado(parametros);
        }

        [HttpPut("{IdCorreoEmpleado}")]
        public async Task<ActionResult> Put(int IdCorreoEmpleado, [FromBody] MEmpleadoCorreoEmpleado parametros)
        {
            var funcion = new DEmpleadoCorreoEmpleado();
            parametros.IdCorreoEmpleado = IdCorreoEmpleado;
            await funcion.EditarCorreoEmpleado(parametros);
            return NoContent();
        }

        [HttpDelete("{IdCorreoEmpleado}")]
        public async Task<ActionResult> Delete(int IdCorreoEmpleado)
        {
            var funcion = new DEmpleadoCorreoEmpleado();
            var parametros = new MEmpleadoCorreoEmpleado();
            parametros.IdCorreoEmpleado = IdCorreoEmpleado;
            await funcion.EliminarCorreoEmpleado(parametros);
            return NoContent();

        }
    }
}
