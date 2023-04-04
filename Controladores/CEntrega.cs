using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/entrega")]
    public class CEntrega : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MEntrega>>> Get()
        {
            var funcion = new DEntrega();
            var lista = await funcion.MostrarEntregas();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] MEntrega parametros)
        {
            var funcion = new DEntrega();
            await funcion.InsertarEntrega(parametros);
        }

        [HttpPut("{CodEntrega}")]
        public async Task<ActionResult> Put(int CodEntrega, [FromBody] MEntrega parametros)
        {
            var funcion = new DEntrega();
            parametros.CodEntrega = CodEntrega;
            await funcion.EditarEntrega(parametros);
            return NoContent();
        }

        [HttpDelete("{CodEntrega}")]
        public async Task<ActionResult> Delete(int CodEntrega)
        {
            var funcion = new DEntrega();
            var parametros = new MEntrega();
            parametros.CodEntrega = CodEntrega;
            await funcion.EliminarEntrega(parametros);
            return NoContent();
        }
    }
}
