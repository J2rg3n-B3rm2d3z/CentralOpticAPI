using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/pagototal")]
    public class CPagoTotal : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task<ActionResult<List<MPagoTotal>>> Get()
        {
            var funcion = new DPagoTotal();
            var lista = await funcion.MostrarPagoTotal();
            return lista;
        }

        [HttpGet("{Numero_Factura}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task<ActionResult<List<MPagoTotal>>> Get(int Numero_Factura)
        {
            var funcion = new DPagoTotal();
            MPagoTotal mPagoTotal = new MPagoTotal();
            mPagoTotal.Numero_Factura = Numero_Factura;
            var lista = await funcion.MostrarPagoTotalByFactura(mPagoTotal);
            return lista;
        }

        //[HttpPost]
        //[Authorize(Roles = ("Administrador, Empleado"))]
        //public async Task Post([FromBody] MPago parametros)
        //{
        //    var funcion = new DPago();
        //    await funcion.InsertarPago(parametros);
        //}

        //[HttpPut("{IdPago}")]
        //[Authorize(Roles = ("Administrador, Empleado"))]
        //public async Task<ActionResult> Put(int IdPago, [FromBody] MPago parametros)
        //{
        //    var funcion = new DPago();
        //    parametros.IdPago = IdPago;
        //    await funcion.EditarPago(parametros);
        //    return NoContent();
        //}

        //[HttpDelete("{IdPago}")]
        //[Authorize(Roles = ("Administrador"))]
        //public async Task<ActionResult> Delete(int IdPago)
        //{
        //    var funcion = new DPago();
        //    var parametros = new MPago();
        //    parametros.IdPago = IdPago;
        //    await funcion.EliminarPago(parametros);
        //    return NoContent();

        //}
    }
}
