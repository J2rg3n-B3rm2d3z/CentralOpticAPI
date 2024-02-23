using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/pago")]
    public class CPago : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task<ActionResult<List<MPago>>> Get()
        {
            var funcion = new DPago();
            var lista = await funcion.MostrarPago();
            return lista;
        }

        [HttpGet("{Id_Pago}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task<ActionResult<List<MPago>>> Get(string Id_Pago)
        {
            var funcion = new DPago();
            MPago mPago = new MPago();

            if (int.TryParse(Id_Pago, out int Id_PagoInt))
            {
                mPago.Id_Pago = Id_PagoInt;
                var lista = await funcion.MostrarPagoById(mPago);

                return lista;
            }
            else
            {
                if (bool.TryParse(Id_Pago, out bool Id_PagoBool))
                {
                    mPago.Estado = Id_PagoBool;
                    var lista = await funcion.MostrarPagoValido(mPago);

                    return lista;
                }
                else
                {
                    return BadRequest("El formato de peticion no es válido.");
                }
            }
        }

        [HttpGet("factura-{Numero_Factura}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task<ActionResult<List<MPago>>> Get(int Numero_Factura)
        {
            var funcion = new DPago();
            MPago mPago = new MPago();
            mPago.Numero_Factura = Numero_Factura;
            var lista = await funcion.MostrarPagoByFactura(mPago);
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task Post([FromBody] MPago parametros)
        {
            var funcion = new DPago();
            await funcion.InsertarPago(parametros);
        }

        [HttpPut("{IdPago}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task<ActionResult> Put(int IdPago, [FromBody] MPago parametros)
        {
            var funcion = new DPago();
            parametros.Id_Pago = IdPago;
            await funcion.EditarPago(parametros);
            return NoContent();
        }

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
