using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/estadopedido")]
    [Authorize(Roles = ("Administrador"))]
    public class CEstadoPedido:Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MEstadoPedido>>> Get()
        {
            var funcion = new DEstadoPedido();
            var lista = await funcion.MostrarEstadoPedido();
            return lista;
        }
    }
}
