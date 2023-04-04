using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/detallefactura")]
    public class CDetalleFactura : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MDetalleFactura>>> Get()
        {
            var funcion = new DDetalleFactura();
            var lista = await funcion.MostrarDetalleFacturas();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] MDetalleFactura parametros)
        {
            var funcion = new DDetalleFactura();
            await funcion.InsertarDetalleFactura(parametros);
        }

        [HttpPut("{IdDetalleFactura}")]
        public async Task<ActionResult> Put(int IdDetalleFactura, [FromBody] MDetalleFactura parametros)
        {
            var funcion = new DDetalleFactura();
            parametros.IdDetalleFactura = IdDetalleFactura;
            await funcion.EditarDetalleFactura(parametros);
            return NoContent();
        }

        [HttpDelete("{IdDetalleFactura}")]
        public async Task<ActionResult> Delete(int IdDetalleFactura)
        {
            var funcion = new DDetalleFactura();
            var parametros = new MDetalleFactura();
            parametros.IdDetalleFactura = IdDetalleFactura;
            await funcion.EliminarDetalleFactura(parametros);
            return NoContent();

        }
    }
}
