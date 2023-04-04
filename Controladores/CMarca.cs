using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/marca")]
    public class CMarca : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MMarca>>> Get()
        {
            var funcion = new DMarca();
            var lista = await funcion.MostrarMarcas();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] MMarca parametros)
        {
            var funcion = new DMarca();
            await funcion.InsertarMarca(parametros);
        }

        [HttpPut("{IdMarca}")]
        public async Task<ActionResult> Put(int IdMarca, [FromBody] MMarca parametros)
        {
            var funcion = new DMarca();
            parametros.IdMarca = IdMarca;
            await funcion.EditarMarca(parametros);
            return NoContent();
        }

        [HttpDelete("{IdMarca}")]
        public async Task<ActionResult> Delete(int IdMarca)
        {
            var funcion = new DMarca();
            var parametros = new MMarca();
            parametros.IdMarca = IdMarca;
            await funcion.EliminarMarca(parametros);
            return NoContent();

        }
    }
}
