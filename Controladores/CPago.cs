using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/pago")]
    public class CPago : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MPago>>> Get()
        {
            var funcion = new DPago();
            var lista = await funcion.MostrarPago();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] MPago parametros)
        {
            var funcion = new DPago();
            await funcion.InsertarPago(parametros);
        }

        [HttpPut("{IdPago}")]
        public async Task<ActionResult> Put(int IdPago, [FromBody] MPago parametros)
        {
            var funcion = new DPago();
            parametros.IdPago = IdPago;
            await funcion.EditarPago(parametros);
            return NoContent();
        }

        [HttpDelete("{IdPago}")]
        public async Task<ActionResult> Delete(int IdPago)
        {
            var funcion = new DPago();
            var parametros = new MPago();
            parametros.IdPago = IdPago;
            await funcion.EliminarPago(parametros);
            return NoContent();

        }
    }
}
