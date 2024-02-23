using CentralOpticAPI.Modelos;
using CentralOpticAPI.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/telefonoempleado")]
    public class CTelefonoEmpleado:Controller
    {
        //[HttpGet]
        //[Authorize(Roles = ("Administrador, Empleado"))]
        //public async Task<ActionResult<List<MTelefonoEmpleado>>> Get()
        //{
        //    var funcion = new DTelefonoEmpleado();
        //    var lista = await funcion.MostrarTelefonoEmpleado();
        //    return lista;
        //}

        [HttpPost]
        [Authorize(Roles = ("Super Administrador, Administrador"))]
        public async Task Post([FromBody] MTelefonoEmpleado parametros)
        {
            var funcion = new DTelefonoEmpleado();
            await funcion.InsertarTelefonoEmpleado(parametros);
        }

        [HttpPut]
        [Authorize(Roles = ("Super Administrador, Administrador"))]
        public async Task<ActionResult> Put([FromBody] MTelefonoEmpleado parametros)
        {
            var funcion = new DTelefonoEmpleado();
            await funcion.EditarTelefonoEmpleado(parametros);
            return NoContent();
        }

        //[HttpDelete("{IdTelefonoEmpleado}")]
        //[Authorize(Roles = ("Super Administrador, Administrador"))]
        //public async Task<ActionResult> Delete(int IdTelefonoEmpleado)
        //{
        //    var funcion = new DTelefonoEmpleado();
        //    var parametros = new MTelefonoEmpleado();
        //    parametros.IdTelefonoEmpleado = IdTelefonoEmpleado;
        //    await funcion.EliminarTelefonoEmpleado(parametros);
        //    return NoContent();

        //}
    }
}
