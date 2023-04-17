using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/cliente")]
    public class CCliente : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult<List<MCliente>>> Get()
        {
            var funcion = new DCliente();
            var lista = await funcion.MostrarClientes();
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task Post([FromBody] MCliente parametros)
        {
            var funcion = new DCliente();
            await funcion.InsertarCliente(parametros);
        }

        [HttpPut("{CodCliente}")]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult> Put(int CodCliente, [FromBody] MCliente parametros)
        {
            var funcion = new DCliente();
            parametros.CodCliente = CodCliente;
            await funcion.EditarCliente(parametros);
            return NoContent();
        }

        [HttpDelete("{CodCliente}")]
        [Authorize(Roles = ("Administrador"))]
        public async Task<ActionResult> Delete(int CodCliente)
        {
            var funcion = new DCliente();
            var parametros = new MCliente();
            parametros.CodCliente = CodCliente;
            await funcion.EliminarCliente(parametros);
            return NoContent();

        }
    }
}
