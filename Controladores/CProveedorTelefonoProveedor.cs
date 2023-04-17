using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/telefonoproveedor")]
    public class CProveedorTelefonoProveedor : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult<List<MProveedorTelefonoProveedor>>> Get()
        {
            var funcion = new DProveedorTelefonoProveedor();
            var lista = await funcion.MostrarTelefonoProveedor();
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task Post([FromBody] MProveedorTelefonoProveedor parametros)
        {
            var funcion = new DProveedorTelefonoProveedor();
            await funcion.InsertarTelefonoProveedor(parametros);
        }

        [HttpPut("{IdTelefonoProveedor}")]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult> Put(int IdTelefonoProveedor, [FromBody] MProveedorTelefonoProveedor parametros)
        {
            var funcion = new DProveedorTelefonoProveedor();
            parametros.IdTelefonoProveedor = IdTelefonoProveedor;
            await funcion.EditarTelefonoProveedor(parametros);
            return NoContent();
        }

        [HttpDelete("{IdTelefonoProveedor}")]
        [Authorize(Roles = ("Administrador"))]
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
