﻿using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/bodega")]
    public class CBodega : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult<List<MBodega>>> Get()
        {
            var funcion = new DBodega();
            var lista = await funcion.MostrarBodegas();
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task Post([FromBody] MBodega parametros)
        {
            var funcion = new DBodega();
            await funcion.InsertarBodega(parametros);
        }

        [HttpPut("{IdBodega}")]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult> Put(int IdBodega, [FromBody] MBodega parametros)
        {
            var funcion = new DBodega();
            parametros.IdBodega = IdBodega;
            await funcion.EditarBodega(parametros);
            return NoContent();
        }

        [HttpDelete("{IdBodega}")]
        [Authorize(Roles = ("Administrador"))]
        public async Task<ActionResult> Delete(int IdBodega)
        {
            var funcion = new DBodega();
            var parametros = new MBodega();
            parametros.IdBodega = IdBodega;
            await funcion.EliminarBodega(parametros);
            return NoContent();
        }
    }
}
