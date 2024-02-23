using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/estadoordenlente")]
    public class CEstadoOrdenLente:Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista"))]
        public async Task<ActionResult<List<MEstadoOrdenLente>>> Get()
        {
            var funcion = new DEstadoOrdenLente();
            var lista = await funcion.MostrarEstadoPedido();
            return lista;
        }

        [HttpGet("{Id_EstadoOrdenLente}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista"))]
        public async Task<ActionResult<List<MEstadoOrdenLente>>> Get(int Id_EstadoOrdenLente)
        {
            var funcion = new DEstadoOrdenLente();
            MEstadoOrdenLente mEstadoOrdenLente = new MEstadoOrdenLente();
            mEstadoOrdenLente.Id_EstadoOrdenLente = Id_EstadoOrdenLente;
            var lista = await funcion.MostrarEstadoPedidoById(mEstadoOrdenLente);
            return lista;
        }
    }
}
