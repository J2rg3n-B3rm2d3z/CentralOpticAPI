using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/telefonocliente")]
    public class CTelefonoCliente : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult<List<MTelefonoCliente>>> Get()
        {
            var funcion = new DTelefonoCliente();
            var lista = await funcion.MostrarTelefonoClientes();
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task Post([FromBody] MTelefonoCliente parametros)
        {
            var funcion = new DTelefonoCliente();
            await funcion.InsertarTelefonoCliente(parametros);
        }

        [HttpPut("{IdTelefonoCliente}")]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult> Put(int IdTelefonoCliente, [FromBody] MTelefonoCliente parametros)
        {
            var funcion = new DTelefonoCliente();
            parametros.IdTelefonoCliente = IdTelefonoCliente;
            await funcion.EditarTelefonoCliente(parametros);
            return NoContent();
        }

        [HttpDelete("{IdTelefonoCliente}")]
        [Authorize(Roles = ("Administrador"))]
        public async Task<ActionResult> Delete(int IdTelefonoCliente)
        {
            var funcion = new DTelefonoCliente();
            var parametros = new MTelefonoCliente();
            parametros.IdTelefonoCliente = IdTelefonoCliente;
            await funcion.EliminarTelefonoCliente(parametros);
            return NoContent();

        }
    }
}
