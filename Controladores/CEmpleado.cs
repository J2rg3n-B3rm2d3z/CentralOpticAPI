using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/empleado")]
    public class CEmpleado : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Super Administrador, Administrador"))]
        public async Task<ActionResult<List<MEmpleado>>> Get()
        {
            var funcion = new DEmpleado();
            var lista = await funcion.MostrarEmpleado();
            return lista;
        }

        [HttpGet("{NumEmpleado}")]
        [Authorize(Roles = ("Super Administrador, Administrador"))]
        public async Task<ActionResult<List<MEmpleado>>> Get(string NumEmpleado)
        {
            var funcion = new DEmpleado();
            MEmpleado mempleado = new MEmpleado();
            if (int.TryParse(NumEmpleado, out int NumEmpleadoInt))
            {
                mempleado.NumEmpleado = NumEmpleadoInt;
                var lista = await funcion.MostrarEmpleadoById(mempleado);
          
                return lista;
            }
            else
            {
                if (bool.TryParse(NumEmpleado, out bool NumEmpleadoBool))
                {
                    mempleado.Estado = NumEmpleadoBool;
                    var lista = await funcion.MostrarEmpleadoActivo(mempleado);

                    return lista;
                }
                else
                {
                    return BadRequest("El formato de peticion no es válido.");
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = ("Super Administrador, Administrador"))]
        public async Task Post([FromBody] MEmpleado parametros)
        {
            var funcion = new DEmpleado();
            await funcion.InsertarEmpleado(parametros);
        }

        [HttpPut("{NumEmpleado}")]
        [Authorize(Roles = ("Super Administrador, Administrador"))]
        public async Task<ActionResult> Put(int NumEmpleado, [FromBody] MEmpleado parametros)
        {
            var funcion = new DEmpleado();
            parametros.NumEmpleado = NumEmpleado;
            await funcion.EditarEmpleado(parametros);
            return NoContent();
        }

        //[HttpDelete("{NumEmpleado}")]
        //[Authorize(Roles = ("Administrador"))]
        //public async Task<ActionResult> Delete(int NumEmpleado)
        //{
        //    var funcion = new DEmpleado();
        //    var parametros = new MEmpleado();
        //    parametros.NumEmpleado = NumEmpleado;
        //    await funcion.EliminarEmpleado(parametros);
        //    return NoContent();

        //}
    }
}
