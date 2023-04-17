using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/correoempleado")]
    public class CEmpleadoCorreoEmpleado :Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult<List<MEmpleadoCorreoEmpleado>>> Get()
        {
            var funcion = new DEmpleadoCorreoEmpleado();
            var lista = await funcion.MostrarCorreoEmpleado();
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task Post([FromBody] MEmpleadoCorreoEmpleado parametros)
        {
            var funcion = new DEmpleadoCorreoEmpleado();
            await funcion.InsertarCorreoEmpleado(parametros);
        }

        [HttpPut("{IdCorreoEmpleado}")]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult> Put(int IdCorreoEmpleado, [FromBody] MEmpleadoCorreoEmpleado parametros)
        {
            var funcion = new DEmpleadoCorreoEmpleado();
            parametros.IdCorreoEmpleado = IdCorreoEmpleado;
            await funcion.EditarCorreoEmpleado(parametros);
            return NoContent();
        }

        [HttpDelete("{IdCorreoEmpleado}")]
        [Authorize(Roles = ("Administrador"))]
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
