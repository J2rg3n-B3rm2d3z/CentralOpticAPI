using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/tipoproducto")]
    public class CTipoProducto : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult<List<MTipoProducto>>> Get()
        {
            var funcion = new DTipoProducto();
            var lista = await funcion.MostrarTipoProducto();
            return lista;
        }

        [HttpGet("{IdTipoProducto}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult<List<MTipoProducto>>> Get(string IdTipoProducto)
        {
            var funcion = new DTipoProducto();
            MTipoProducto tipoproducto = new MTipoProducto();
            tipoproducto.Id_TipoProducto = IdTipoProducto;
            var lista = await funcion.MostrarTipoProductoById(tipoproducto);
            return lista;
        }

        //[HttpPost]
        //[Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        //public async Task Post([FromBody] MTipoProducto parametros)
        //{
        //    var funcion = new DTipoProducto();
        //    await funcion.InsertarMarca(parametros);
        //}

        //[HttpPut("{IdMarca}")]
        //[Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        //public async Task<ActionResult> Put(int IdMarca, [FromBody] MTipoProducto parametros)
        //{
        //    var funcion = new DTipoProducto();
        //    parametros.IdMarca = IdMarca;
        //    await funcion.EditarMarca(parametros);
        //    return NoContent();
        //}

        //[HttpDelete("{IdMarca}")]
        //[Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        //public async Task<ActionResult> Delete(int IdMarca)
        //{
        //    var funcion = new DTipoProducto();
        //    var parametros = new MTipoProducto();
        //    parametros.IdMarca = IdMarca;
        //    await funcion.EliminarMarca(parametros);
        //    return NoContent();

        //}
    }
}
