using CentralOpticAPI.Modelos;
using CentralOpticAPI.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/telefonoempleado")]
    public class CEmpleadoTelefonoEmpleado:Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult<List<MEmpleadoTelefonoEmpleado>>> Get()
        {
            var funcion = new DEmpleadoTelefonoEmpleado();
            var lista = await funcion.MostrarTelefonoEmpleado();
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task Post([FromBody] MEmpleadoTelefonoEmpleado parametros)
        {
            var funcion = new DEmpleadoTelefonoEmpleado();
            await funcion.InsertarTelefonoEmpleado(parametros);
        }

        [HttpPut("{IdTelefonoEmpleado}")]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult> Put(int IdTelefonoEmpleado, [FromBody] MEmpleadoTelefonoEmpleado parametros)
        {
            var funcion = new DEmpleadoTelefonoEmpleado();
            parametros.IdTelefonoEmpleado = IdTelefonoEmpleado;
            await funcion.EditarTelefonoEmpleado(parametros);
            return NoContent();
        }

        [HttpDelete("{IdTelefonoEmpleado}")]
        [Authorize(Roles = ("Administrador"))]
        public async Task<ActionResult> Delete(int IdTelefonoEmpleado)
        {
            var funcion = new DEmpleadoTelefonoEmpleado();
            var parametros = new MEmpleadoTelefonoEmpleado();
            parametros.IdTelefonoEmpleado = IdTelefonoEmpleado;
            await funcion.EliminarTelefonoEmpleado(parametros);
            return NoContent();

        }
    }
}
