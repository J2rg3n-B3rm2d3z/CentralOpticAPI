using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/telefonoproveedor")]
    public class CProveedorTelefonoProveedor : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MProveedorTelefonoProveedor>>> Get()
        {
            var funcion = new DProveedorTelefonoProveedor();
            var lista = await funcion.MostrarTelefonoProveedor();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] MProveedorTelefonoProveedor parametros)
        {
            var funcion = new DProveedorTelefonoProveedor();
            await funcion.InsertarTelefonoProveedor(parametros);
        }

        [HttpPut("{IdTelefonoProveedor}")]
        public async Task<ActionResult> Put(int IdTelefonoProveedor, [FromBody] MProveedorTelefonoProveedor parametros)
        {
            var funcion = new DProveedorTelefonoProveedor();
            parametros.IdTelefonoProveedor = IdTelefonoProveedor;
            await funcion.EditarTelefonoProveedor(parametros);
            return NoContent();
        }

        [HttpDelete("{IdTelefonoProveedor}")]
        public async Task<ActionResult> Delete(int IdTelefonoProveedor)
        {
            var funcion = new DProveedorTelefonoProveedor();
            var parametros = new MProveedorTelefonoProveedor();
            parametros.IdTelefonoProveedor = IdTelefonoProveedor;
            await funcion.EliminarTelefonoProveedor(parametros);
            return NoContent();

        }
    }
}
