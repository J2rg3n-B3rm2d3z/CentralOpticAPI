using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/correoproveedor")]
    public class CCorreoProveedor : Controller
    {
        //[HttpGet]
        //[Authorize(Roles = ("Administrador, Empleado"))]
        //public async Task<ActionResult<List<MCorreoProveedor>>> Get()
        //{
        //    var funcion = new DCorreoProveedor();
        //    var lista = await funcion.MostrarCorreoProveedor();
        //    return lista;
        //}

        [HttpPost]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task Post([FromBody] MCorreoProveedor parametros)
        {
            var funcion = new DCorreoProveedor();
            await funcion.InsertarCorreoProveedor(parametros);
        }

        [HttpPut]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task<ActionResult> Put([FromBody] MCorreoProveedor parametros)
        {
            var funcion = new DCorreoProveedor();
            await funcion.EditarCorreoProveedor(parametros);
            return NoContent();
        }

        //[HttpDelete("{IdCorreoProveedor}")]
        //[Authorize(Roles = ("Administrador"))]
        //public async Task<ActionResult> Delete(int IdCorreoProveedor)
        //{
        //    var funcion = new DCorreoProveedor();
        //    var parametros = new MCorreoProveedor();
        //    parametros.IdCorreoProveedor = IdCorreoProveedor;
        //    await funcion.EliminarCorreoProveedor(parametros);
        //    return NoContent();

        //}
    }
}
