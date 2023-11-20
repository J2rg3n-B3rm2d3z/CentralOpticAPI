using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/producto")]
    public class CProducto:Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult<List<MProducto>>> Get()
        {
            var funcion = new DProducto();
            var lista = await funcion.MostrarProductos();
            return lista;
        }

        [HttpGet("{CodProducto}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult<List<MProducto>>> Get(string CodProducto)
        {
            var funcion = new DProducto();
            MProducto producto = new MProducto();
            producto.CodProducto = CodProducto;
            var lista = await funcion.MostrarProductosbyId(producto);
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task Post([FromBody] MProducto parametros)
        {
            var funcion = new DProducto();
            await funcion.InsertarProducto(parametros);
        }

        [HttpPut("{CodProducto}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult> Put(string CodProducto, [FromBody] MProducto parametros)
        {
            var funcion = new DProducto();
            parametros.CodProducto = CodProducto;
            await funcion.EditarProducto(parametros);
            return NoContent();
        }

        //[HttpDelete("{CodProducto}")]
        //[Authorize(Roles = ("Administrador"))]
        //public async Task<ActionResult> Delete(int CodProducto)
        //{
        //    var funcion = new DProducto();
        //    var parametros = new MProducto();
        //    parametros.CodProducto = CodProducto;
        //    await funcion.EliminarProducto(parametros);
        //    return NoContent();

        //}
    }
}
