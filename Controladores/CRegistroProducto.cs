using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/registroproducto")]
    public class CRegistroProducto : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult<List<MRegistroProducto>>> Get()
        {
            var funcion = new DRegistroProducto();
            var lista = await funcion.MostrarRegistroProducto();
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task Post([FromBody] MRegistroProducto parametros)
        {
            var funcion = new DRegistroProducto();
            await funcion.InsertarRegistroProducto(parametros);
        }

        [HttpPut]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult> Put([FromBody] MRegistroProducto parametros)
        {
            var funcion = new DRegistroProducto();
            await funcion.EditarRegistroProducto(parametros);
            return NoContent();
        }

        //[HttpDelete("{IdProveedor_Producto}")]
        //[Authorize(Roles = ("Administrador"))]
        //public async Task<ActionResult> Delete(int IdProveedor_Producto)
        //{
        //    var funcion = new DRegistroProducto();
        //    var parametros = new MRegistroProducto();
        //    parametros.IdProveedor_Producto = IdProveedor_Producto;
        //    await funcion.EliminarProveedor_Producto(parametros);
        //    return NoContent();
        //}
    }
}
