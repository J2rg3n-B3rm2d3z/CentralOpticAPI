using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/entregalente")]
    public class CEntregaLente : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista"))]
        public async Task<ActionResult<List<MEntregaLente>>> Get()
        {
            var funcion = new DEntregaLente();
            var lista = await funcion.MostrarEntregas();
            return lista;
        }

        [HttpGet("{Codigo_Entrega}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista"))]
        public async Task<ActionResult<List<MEntregaLente>>> Get(string Codigo_Entrega)
        {
            var funcion = new DEntregaLente();
            MEntregaLente mEntregaLente = new MEntregaLente();

            if (int.TryParse(Codigo_Entrega, out int Codigo_EntregaInt))
            {
                mEntregaLente.Codigo_Entrega = Codigo_EntregaInt;
                var lista = await funcion.MostrarEntregasById(mEntregaLente);

                return lista;
            }
            else
            {
                if (bool.TryParse(Codigo_Entrega, out bool Codigo_EntregaBool))
                {
                    mEntregaLente.Estado = Codigo_EntregaBool;
                    var lista = await funcion.MostrarEntregasValidas(mEntregaLente);

                    return lista;
                }
                else
                {
                    return BadRequest("El formato de peticion no es válido.");
                }
            }
        }

        [HttpGet("OrdenLente-{Numero_Orden}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista"))]
        public async Task<ActionResult<List<MEntregaLente>>> Get(int Numero_Orden)
        {
            var funcion = new DEntregaLente();
            MEntregaLente mEntregaLente = new MEntregaLente();
            mEntregaLente.Numero_Orden = Numero_Orden;
            var lista = await funcion.MostrarEntregasByOrden(mEntregaLente);
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista"))]
        public async Task Post([FromBody] MEntregaLente parametros)
        {
            var funcion = new DEntregaLente();
            await funcion.InsertarEntrega(parametros);
        }

        [HttpPut("{CodEntrega}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista"))]
        public async Task<ActionResult> Put(int CodEntrega, [FromBody] MEntregaLente parametros)
        {
            var funcion = new DEntregaLente();
            parametros.Codigo_Entrega = CodEntrega;
            await funcion.EditarEntrega(parametros);
            return NoContent();
        }

        //[HttpDelete("{CodEntrega}")]
        //[Authorize(Roles = ("Super Administrador, Administrador, Optometrista"))]
        //public async Task<ActionResult> Delete(int CodEntrega)
        //{
        //    var funcion = new DEntregaLente();
        //    var parametros = new MEntregaLente();
        //    parametros.CodEntrega = CodEntrega;
        //    await funcion.EliminarEntrega(parametros);
        //    return NoContent();
        //}
    }
}
