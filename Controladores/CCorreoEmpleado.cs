using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/correoempleado")]
    public class CCorreoEmpleado :Controller
    {
        //[HttpGet]
        //[Authorize(Roles = ("Administrador, Empleado"))]
        //public async Task<ActionResult<List<MCorreoEmpleado>>> Get()
        //{
        //    var funcion = new DCorreoEmpleado();
        //    var lista = await funcion.MostrarCorreoEmpleado();
        //    return lista;
        //}

        [HttpPost]
        [Authorize(Roles = ("Super Administrador, Administrador"))]
        public async Task Post([FromBody] MCorreoEmpleado parametros)
        {
            var funcion = new DCorreoEmpleado();
            await funcion.InsertarCorreoEmpleado(parametros);
        }

        [HttpPut]
        [Authorize(Roles = ("Super Administrador, Administrador"))]
        public async Task<ActionResult> Put([FromBody] MCorreoEmpleado parametros)
        {
            var funcion = new DCorreoEmpleado();
            await funcion.EditarCorreoEmpleado(parametros);
            return NoContent();
        }

        //[HttpDelete("{IdCorreoEmpleado}")]
        //[Authorize(Roles = ("Administrador"))]
        //public async Task<ActionResult> Delete(int IdCorreoEmpleado)
        //{
        //    var funcion = new DCorreoEmpleado();
        //    var parametros = new MCorreoEmpleado();
        //    parametros.IdCorreoEmpleado = IdCorreoEmpleado;
        //    await funcion.EliminarCorreoEmpleado(parametros);
        //    return NoContent();

        //}
    }
}
