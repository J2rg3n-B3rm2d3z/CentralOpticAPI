using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/tipopago")]
    public class CTipoPago : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task<ActionResult<List<MTipoPago>>> Get()
        {
            var funcion = new DTipoPago();
            var lista = await funcion.MostrarTipoPago();
            return lista;
        }

        [HttpGet("{Id_TipoPago}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task<ActionResult<List<MTipoPago>>> Get(int Id_TipoPago)
        {
            var funcion = new DTipoPago();
            MTipoPago mTipoPago = new MTipoPago();
            mTipoPago.Id_TipoPago = Id_TipoPago;
            var lista = await funcion.MostrarTipoPagoById(mTipoPago);
            return lista;
        }

        //[HttpPost]
        //[Authorize(Roles = ("Administrador, Empleado"))]
        //public async Task Post([FromBody] MTipoPago parametros)
        //{
        //    var funcion = new DTipoPago();
        //    await funcion.InsertarFechaPago(parametros);
        //}

        //[HttpPut("{IdFechaPago}")]
        //[Authorize(Roles = ("Administrador, Empleado"))]
        //public async Task<ActionResult> Put(int IdFechaPago, [FromBody] MTipoPago parametros)
        //{
        //    var funcion = new DTipoPago();
        //    parametros.IdFechaPago = IdFechaPago;
        //    await funcion.EditarFechaPago(parametros);
        //    return NoContent();
        //}

        //[HttpDelete("{IdFechaPago}")]
        //[Authorize(Roles = ("Administrador"))]
        //public async Task<ActionResult> Delete(int IdFechaPago)
        //{
        //    var funcion = new DTipoPago();
        //    var parametros = new MTipoPago();
        //    parametros.IdFechaPago = IdFechaPago;
        //    await funcion.EliminarFechaPago(parametros);
        //    return NoContent();

        //}
    }
}
