using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/empleado")]
    public class CEmpleado : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult<List<MEmpleado>>> Get()
        {
            var funcion = new DEmpleado();
            var lista = await funcion.MostrarEmpleado();
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task Post([FromBody] MEmpleado parametros)
        {
            var funcion = new DEmpleado();
            await funcion.InsertarEmpleado(parametros);
        }

        [HttpPut("{NumEmpleado}")]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult> Put(int NumEmpleado, [FromBody] MEmpleado parametros)
        {
            var funcion = new DEmpleado();
            parametros.NumEmpleado = NumEmpleado;
            await funcion.EditarEmpleado(parametros);
            return NoContent();
        }

        [HttpDelete("{NumEmpleado}")]
        [Authorize(Roles = ("Administrador"))]
        public async Task<ActionResult> Delete(int NumEmpleado)
        {
            var funcion = new DEmpleado();
            var parametros = new MEmpleado();
            parametros.NumEmpleado = NumEmpleado;
            await funcion.EliminarEmpleado(parametros);
            return NoContent();

        }
    }
}
