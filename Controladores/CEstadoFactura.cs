using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/estadofactura")]
    public class CEstadoFactura : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult<List<MEstadoFactura>>> Get()
        {
            var funcion = new DEstadoFactura();
            var lista = await funcion.MostrarEstadoFacturas();
            return lista;
        }

        [HttpGet("{Id_EstadoFactura}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult<List<MEstadoFactura>>> Get(int Id_EstadoFactura)
        {
            var funcion = new DEstadoFactura();
            MEstadoFactura mEstadoFactura = new MEstadoFactura();
            mEstadoFactura.IdEstadoFactura = Id_EstadoFactura;
            var lista = await funcion.MostrarEstadoFacturasById(mEstadoFactura);
            return lista;
        }
    }
}
