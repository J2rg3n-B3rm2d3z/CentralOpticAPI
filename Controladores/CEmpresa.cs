using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/empresa")]
    public class CEmpresa:Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult<List<MEmpresa>>> Get()
        {
            var funcion = new DEmpresa();
            var lista = await funcion.MostrarEmpresa();
            return lista;
        }

        [HttpGet("{Id_Empresa}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult<List<MEmpresa>>> Get(int Id_Empresa)
        {
            var funcion = new DEmpresa();
            MEmpresa mempresa = new MEmpresa();
            mempresa.Id_Empresa = Id_Empresa;
            var lista = await funcion.MostrarEmpresaById(mempresa);
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task Post([FromBody] MEmpresa parametros)
        {
            var funcion = new DEmpresa();
            await funcion.InsertarEmpresa(parametros);
        }

        [HttpPut("{Id_Empresa}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult> Put(int Id_Empresa, [FromBody] MEmpresa parametros)
        {
            var funcion = new DEmpresa();
            parametros.Id_Empresa = Id_Empresa;
            await funcion.EditarEmpresa(parametros);
            return NoContent();
        }
    }
}
