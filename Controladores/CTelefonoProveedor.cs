using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/telefonoproveedor")]
    public class CTelefonoProveedor : Controller
    {
        //[HttpGet]
        //[Authorize(Roles = ("Administrador, Empleado"))]
        //public async Task<ActionResult<List<MTelefonoProveedor>>> Get()
        //{
        //    var funcion = new DTelefonoProveedor();
        //    var lista = await funcion.MostrarTelefonoProveedor();
        //    return lista;
        //}

        [HttpPost]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task Post([FromBody] MTelefonoProveedor parametros)
        {
            var funcion = new DTelefonoProveedor();
            await funcion.InsertarTelefonoProveedor(parametros);
        }

        [HttpPut]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task<ActionResult> Put([FromBody] MTelefonoProveedor parametros)
        {
            var funcion = new DTelefonoProveedor();
            await funcion.EditarTelefonoProveedor(parametros);
            return NoContent();
        }

        //[HttpDelete("{IdTelefonoProveedor}")]
        //[Authorize(Roles = ("Administrador"))]
        //public async Task<ActionResult> Delete(int IdTelefonoProveedor)
        //{
        //    var funcion = new DTelefonoProveedor();
        //    var parametros = new MTelefonoProveedor();
        //    parametros.IdTelefonoProveedor = IdTelefonoProveedor;
        //    await funcion.EliminarTelefonoProveedor(parametros);
        //    return NoContent();

        //}
    }
}
