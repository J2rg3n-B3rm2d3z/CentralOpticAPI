using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/detallefactura")]
    public class CDetalleFactura : Controller
    {
        [HttpGet("{NumFactura}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task<ActionResult<List<MDetalleFactura>>> Get(int NumFactura)
        {
            var funcion = new DDetalleFactura();
            MDetalleFactura mDetalleFactura = new MDetalleFactura();
            mDetalleFactura.NumFactura = NumFactura;
            var lista = await funcion.MostrarDetalleFacturas(mDetalleFactura);
            return lista;
        }

        [HttpPost("{NumFactura}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task Post(int NumFactura, [FromBody] MDetalleFactura parametros)
        {
            var funcion = new DDetalleFactura();
            parametros.NumFactura = NumFactura;
            await funcion.InsertarDetalleFactura(parametros);
        }
    }
}
