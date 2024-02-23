using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/laboratorio")]
    public class CLaboratorio:Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista"))]
        public async Task<ActionResult<List<MLaboratorio>>> Get()
        {
            var funcion = new DLaboratorio();
            var lista = await funcion.MostrarLaboratorios();
            return lista;
        }

        [HttpGet("{Codigo_Laboratorio}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista"))]
        public async Task<ActionResult<List<MLaboratorio>>> Get(string Codigo_Laboratorio)
        {
            var funcion = new DLaboratorio();
            MLaboratorio mLaboratorio = new MLaboratorio();
            if (int.TryParse(Codigo_Laboratorio, out int Codigo_LaboratorioInt))
            {
                mLaboratorio.Codigo_Laboratorio = Codigo_LaboratorioInt;
                var lista = await funcion.MostrarLaboratoriosById(mLaboratorio);

                return lista;
            }
            else
            {
                if (bool.TryParse(Codigo_Laboratorio, out bool Codigo_LaboratorioBool))
                {
                    mLaboratorio.Estado = Codigo_LaboratorioBool; 
                    var lista = await funcion.MostrarLaboratoriosActivos(mLaboratorio);

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
        public async Task Post([FromBody] MLaboratorio parametros)
        {
            var funcion = new DLaboratorio();
            await funcion.InsertarLaboratorio(parametros);
        }

        [HttpPut("{Codigo_Laboratorio}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista"))]
        public async Task<ActionResult> Put(int Codigo_Laboratorio, [FromBody] MLaboratorio parametros)
        {
            var funcion = new DLaboratorio();
            parametros.Codigo_Laboratorio = Codigo_Laboratorio;
            await funcion.EditarLaboratorio(parametros);
            return NoContent();
        }

        //[HttpDelete("{IdLaboratorio}")]
        //[Authorize(Roles = ("Administrador"))]
        //public async Task<ActionResult> Delete(int IdLaboratorio)
        //{
        //    var funcion = new DLaboratorio();
        //    var parametros = new MLaboratorio();
        //    parametros.IdLaboratorio = IdLaboratorio;
        //    await funcion.EliminarLaboratorio(parametros);
        //    return NoContent();
        //}
    }
}
