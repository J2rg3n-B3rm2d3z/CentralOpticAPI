using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/estadoentrega")]
    [Authorize(Roles = ("Administrador, Empleado"))]
    public class CEstadoEntrega:Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MEstadoEntrega>>> Get()
        {
            var funcion = new DEstadoEntrega();
            var lista = await funcion.MostrarEstadoEntregas();
            return lista;
        }
    }
}
