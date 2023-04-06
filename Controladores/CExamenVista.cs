using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/examenvista")]
    public class CExamenVista : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MExamenVista>>> Get()
        {
            var funcion = new DExamenVista();
            var lista = await funcion.MostrarExamenVista();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] MExamenVista parametros)
        {
            var funcion = new DExamenVista();
            await funcion.InsertarExamenVista(parametros);
        }

        [HttpPut("{NumExamenVista}")]
        public async Task<ActionResult> Put(int NumExamen, [FromBody] MExamenVista parametros)
        {
            var funcion = new DExamenVista();
            parametros.NumExamen = NumExamen;
            await funcion.EditarExamenVista(parametros);
            return NoContent();
        }

        [HttpDelete("{NumExamenVista}")]
        public async Task<ActionResult> Delete(int NumExamen)
        {
            var funcion = new DExamenVista();
            var parametros = new MExamenVista();
            parametros.NumExamen = NumExamen;
            await funcion.EliminarExamenVista(parametros);
            return NoContent();

        }
    }
}
