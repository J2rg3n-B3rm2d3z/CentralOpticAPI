using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/cliente")]
    public class CCliente : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MCliente>>> Get()
        {
            var funcion = new DCliente();
            var lista = await funcion.MostrarClientes();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] MCliente parametros)
        {
            var funcion = new DCliente();
            await funcion.InsertarCliente(parametros);
        }

        [HttpPut("{CodCliente}")]
        public async Task<ActionResult> Put(int CodCliente, [FromBody] MCliente parametros)
        {
            var funcion = new DCliente();
            parametros.CodCliente = CodCliente;
            await funcion.EditarCliente(parametros);
            return NoContent();
        }

        [HttpDelete("{CodCliente}")]
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
