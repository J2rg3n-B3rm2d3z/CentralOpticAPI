using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/factura")]
    public class CFactura :Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult<List<MFactura>>> Get()
        {
            var funcion = new DFactura();
            var lista = await funcion.MostrarFacturas();
            return lista;
        }

        [HttpGet("{NumFactura}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult<List<MFactura>>> Get(int NumFactura)
        {
            var funcion = new DFactura();
            MFactura mFactura = new MFactura();
            mFactura.NumFactura = NumFactura;
            var lista = await funcion.MostrarFacturasbyId(mFactura);
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task Post([FromBody] MFacturaIngreso parametros)
        {
            var funcion = new DFactura();
            await funcion.InsertarFactura(parametros);
        }

        [HttpPut("{NumFactura}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult> Put(int NumFactura, [FromBody] MFacturaIngreso parametros)
        {
            var funcion = new DFactura();
            parametros.NumFactura = NumFactura;
            await funcion.EditarFactura(parametros);
            return NoContent();
        }

        //[HttpDelete("{NumFactura}")]
        //[Authorize(Roles = ("Administrador"))]
        //public async Task<ActionResult> Delete(int NumFactura)
        //{
        //    var funcion = new DFactura();
        //    var parametros = new MFactura();
        //    parametros.NumFactura = NumFactura;
        //    await funcion.EliminarFactura(parametros);
        //    return NoContent();

        //}
    }
}
