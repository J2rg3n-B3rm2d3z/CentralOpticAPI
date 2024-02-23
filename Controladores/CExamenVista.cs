using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/examen")]
    public class CExamenVista : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista"))]
        public async Task<ActionResult<List<MExamenVista>>> Get()
        {
            var funcion = new DExamenVista();
            var lista = await funcion.MostrarExamenVista();
            return lista;
        }

        [HttpGet("{NumExamen}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista"))]
        public async Task<ActionResult<List<MExamenVista>>> Get(string NumExamen)
        {
            var funcion = new DExamenVista();
            MExamenVista mExamenVista = new MExamenVista();

            if (int.TryParse(NumExamen, out int NumExamenInt))
            {
                mExamenVista.NumExamen = NumExamenInt;
                var lista = await funcion.MostrarExamenVistaById(mExamenVista);
                
                return lista;
            }
            else
            {
                if (bool.TryParse(NumExamen, out bool NumExamenBool))
                {
                    mExamenVista.Estado = NumExamenBool;
                    var lista = await funcion.MostrarExamenVistaValido(mExamenVista);
                    
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
        public async Task Post([FromBody] MExamenVistaIngreso parametros)
        {
            var funcion = new DExamenVista();
            await funcion.InsertarExamenVista(parametros);
        }

        [HttpPut("{NumExamenVista}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista"))]
        public async Task<ActionResult> Put(int NumExamenVista, [FromBody] MExamenVistaIngreso parametros)
        {
            var funcion = new DExamenVista();
            parametros.NumExamen = NumExamenVista;
            await funcion.EditarExamenVista(parametros);
            return NoContent();
        }

        //[HttpDelete("{NumExamenVista}")]
        //[Authorize(Roles = ("Administrador"))]
        //public async Task<ActionResult> Delete(int NumExamenVista)
        //{
        //    var funcion = new DExamenVista();
        //    var parametros = new MExamenVista();
        //    parametros.NumExamen = NumExamenVista;
        //    await funcion.EliminarExamenVista(parametros);
        //    return NoContent();

        //}
    }
}
