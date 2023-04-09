using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/correoproveedor")]
    [Authorize(Roles = ("Administrador"))]
    public class CProveedorCorreoProveedor : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MProveedorCorreoProveedor>>> Get()
        {
            var funcion = new DProveedorCorreoProveedor();
            var lista = await funcion.MostrarCorreoProveedor();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] MProveedorCorreoProveedor parametros)
        {
            var funcion = new DProveedorCorreoProveedor();
            await funcion.InsertarCorreoProveedor(parametros);
        }

        [HttpPut("{IdCorreoProveedor}")]
        public async Task<ActionResult> Put(int IdCorreoProveedor, [FromBody] MProveedorCorreoProveedor parametros)
        {
            var funcion = new DProveedorCorreoProveedor();
            parametros.IdCorreoProveedor = IdCorreoProveedor;
            await funcion.EditarCorreoProveedor(parametros);
            return NoContent();
        }

        [HttpDelete("{IdCorreoProveedor}")]
        public async Task<ActionResult> Delete(int IdCorreoProveedor)
        {
            var funcion = new DProveedorCorreoProveedor();
            var parametros = new MProveedorCorreoProveedor();
            parametros.IdCorreoProveedor = IdCorreoProveedor;
            await funcion.EliminarCorreoProveedor(parametros);
            return NoContent();

        }
    }
}
