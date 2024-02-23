using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/ordenlente")]
    public class COrdenLente : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista"))]
        public async Task<ActionResult<List<MOrdenLente>>> Get()
        {
            var funcion = new DOrdenLente();
            var lista = await funcion.MostrarOrdenLente();
            return lista;
        }

        [HttpGet("{Numero_Orden}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista"))]
        public async Task<ActionResult<List<MOrdenLente>>> Get(string Numero_Orden)
        {
            var funcion = new DOrdenLente();
            MOrdenLente mOrdenLente = new MOrdenLente();

            if (int.TryParse(Numero_Orden, out int Numero_OrdenInt))
            {
                mOrdenLente.Numero_Orden = Numero_OrdenInt;
                var lista = await funcion.MostrarOrdenLenteById(mOrdenLente);

                return lista;
            }
            else
            {
                if (bool.TryParse(Numero_Orden, out bool Numero_OrdenBool))
                {

                    var lista = await funcion.MostrarOrdenLenteValido(Numero_OrdenBool);

                    return lista;
                }
                else
                {
                    return BadRequest("El formato de peticion no es válido.");
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista"))]
        public async Task Post([FromBody] MOrdenLenteIngreso parametros)
        {
            var funcion = new DOrdenLente();
            await funcion.InsertarOrdenLente(parametros);
        }

        [HttpPut("{Numero_Orden}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista"))]
        public async Task<ActionResult> Put(int Numero_Orden, [FromBody] MOrdenLente parametros)
        {
            var funcion = new DOrdenLente();
            parametros.Numero_Orden = Numero_Orden;
            await funcion.EditarOrdenPedido(parametros);
            return NoContent();
        }

        //[HttpDelete("{NumOrden}")]
        //[Authorize(Roles = ("Super Administrador, Administrador, Optometrista"))]
        //public async Task<ActionResult> Delete(int NumOrden)
        //{
        //    var funcion = new DOrdenLente();
        //    var parametros = new MOrdenLente();
        //    parametros.NumOrden = NumOrden;
        //    await funcion.EliminarOrdenPedido(parametros);
        //    return NoContent();

        //}
    }
}
