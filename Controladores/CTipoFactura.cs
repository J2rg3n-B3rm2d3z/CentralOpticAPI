using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/tipofactura")]
    public class CTipoFactura : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task<ActionResult<List<MTipoFactura>>> Get()
        {
            var funcion = new DTipoFactura();
            var lista = await funcion.MostrarTipoFacturas();
            return lista;
        }

        [HttpGet("{Id_TipoFactura}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task<ActionResult<List<MTipoFactura>>> Get(int Id_TipoFactura)
        {
            var funcion = new DTipoFactura();
            MTipoFactura mtipofactura = new MTipoFactura();
            mtipofactura.Id_TipoFactura = Id_TipoFactura;
            var lista = await funcion.MostrarTipoFacturasById(mtipofactura);
            return lista;
        }

        //[HttpPost]
        //[Authorize(Roles = ("Administrador, Empleado"))]
        //public async Task Post([FromBody] MTipoFactura parametros)
        //{
        //    var funcion = new DTipoFactura();
        //    await funcion.InsertarFechaFactura(parametros);
        //}

        //[HttpPut("{IdFechaFactura}")]
        //[Authorize(Roles = ("Administrador, Empleado"))]
        //public async Task<ActionResult> Put(int IdFechaFactura, [FromBody] MTipoFactura parametros)
        //{
        //    var funcion = new DTipoFactura();
        //    parametros.IdFechaFactura = IdFechaFactura;
        //    await funcion.EditarFechaFactura(parametros);
        //    return NoContent();
        //}

        //[HttpDelete("{IdFechaFactura}")]
        //[Authorize(Roles = ("Administrador"))]
        //public async Task<ActionResult> Delete(int IdFechaFactura)
        //{
        //    var funcion = new DTipoFactura();
        //    var parametros = new MTipoFactura();
        //    parametros.IdFechaFactura = IdFechaFactura;
        //    await funcion.EliminarFechaFactura(parametros);
        //    return NoContent();

        //}
    }
}
