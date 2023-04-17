using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{

    [ApiController]
    [Route("centralopticapi/proveedor")]
    public class CProveedor : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult<List<MProveedor>>> Get()
        {
            var funcion = new DProveedor();
            var lista = await funcion.MostrarProveedor();
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task Post([FromBody] MProveedor parametros)
        {
            var funcion = new DProveedor();
            await funcion.InsertarProveedor(parametros);
        }

        [HttpPut("{IdProveedor}")]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult> Put(int IdProveedor, [FromBody] MProveedor parametros)
        {
            var funcion = new DProveedor();
            parametros.IdProveedor = IdProveedor;
            await funcion.EditarProveedor(parametros);
            return NoContent();
        }

        [HttpDelete("{IdProveedor}")]
        [Authorize(Roles = ("Administrador"))]
        public async Task<ActionResult> Delete(int IdProveedor)
        {
            var funcion = new DProveedor();
            var parametros = new MProveedor();
            parametros.IdProveedor = IdProveedor;
            await funcion.EliminarProveedor(parametros);
            return NoContent();

        }
    }
}
