using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/factura")]
    public class CFactura :Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task<ActionResult<List<MFactura>>> Get()
        {
            var funcion = new DFactura();
            var lista = await funcion.MostrarFacturas();
            return lista;
        }

        [HttpGet("{NumFactura}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task<ActionResult<List<MFactura>>> Get(string NumFactura)
        {
            var funcion = new DFactura();
            MFactura mFactura = new MFactura();

            if (int.TryParse(NumFactura, out int NumFacturaInt))
            {
                mFactura.NumFactura = NumFacturaInt;
                var lista = await funcion.MostrarFacturasbyId(mFactura);

                return lista;
            }
            else
            {
                if (bool.TryParse(NumFactura, out bool NumFacturaBool))
                {
                    var lista = await funcion.MostrarFacturasValidas(NumFacturaBool);

                    return lista;
                }
                else
                {
                    return BadRequest("El formato de peticion no es válido.");
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task Post([FromBody] MFacturaIngreso parametros)
        {
            var funcion = new DFactura();
            await funcion.InsertarFactura(parametros);
        }

        [HttpPut("{NumFactura}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
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
