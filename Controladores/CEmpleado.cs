using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/empleado")]
    [Authorize(Roles = ("Administrador"))]
    public class CEmpleado : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MEmpleado>>> Get()
        {
            var funcion = new DEmpleado();
            var lista = await funcion.MostrarEmpleado();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] MEmpleado parametros)
        {
            var funcion = new DEmpleado();
            await funcion.InsertarEmpleado(parametros);
        }

        [HttpPut("{NumEmpleado}")]
        public async Task<ActionResult> Put(int NumEmpleado, [FromBody] MEmpleado parametros)
        {
            var funcion = new DEmpleado();
            parametros.NumEmpleado = NumEmpleado;
            await funcion.EditarEmpleado(parametros);
            return NoContent();
        }

        [HttpDelete("{NumEmpleado}")]
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
