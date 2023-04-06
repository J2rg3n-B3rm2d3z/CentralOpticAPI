using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/fechaexamen")]
    public class CExamenVistaFechaExamen : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MExamenVistaFechaExamen>>> Get()
        {
            var funcion = new DExamenVistaFechaExamen();
            var lista = await funcion.MostrarFechaObtencion();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] MExamenVistaFechaExamen parametros)
        {
            var funcion = new DExamenVistaFechaExamen();
            await funcion.InsertarFechaPago(parametros);
        }

        [HttpPut("{IdFechaExamen}")]
        public async Task<ActionResult> Put(int IdFechaExamen, [FromBody] MExamenVistaFechaExamen parametros)
        {
            var funcion = new DExamenVistaFechaExamen();
            parametros.IdFechaExamen = IdFechaExamen;
            await funcion.EditarFechaPago(parametros);
            return NoContent();
        }

        [HttpDelete("{IdFechaExamen}")]
        public async Task<ActionResult> Delete(int IdFechaExamen)
        {
            var funcion = new DExamenVistaFechaExamen();
            var parametros = new MExamenVistaFechaExamen();
            parametros.IdFechaExamen = IdFechaExamen;
            await funcion.EliminarFechaPago(parametros);
            return NoContent();

        }
    }
}
