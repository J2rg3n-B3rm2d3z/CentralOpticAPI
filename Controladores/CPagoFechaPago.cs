﻿using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/fechapago")]
    public class CPagoFechaPago : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MPagoFechaPago>>> Get()
        {
            var funcion = new DPagoFechaPago();
            var lista = await funcion.MostrarFechaObtencion();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] MPagoFechaPago parametros)
        {
            var funcion = new DPagoFechaPago();
            await funcion.InsertarFechaPago(parametros);
        }

        [HttpPut("{IdFechaPago}")]
        public async Task<ActionResult> Put(int IdFechaPago, [FromBody] MPagoFechaPago parametros)
        {
            var funcion = new DPagoFechaPago();
            parametros.IdFechaPago = IdFechaPago;
            await funcion.EditarFechaPago(parametros);
            return NoContent();
        }

        [HttpDelete("{IdFechaPago}")]
        public async Task<ActionResult> Delete(int IdFechaPago)
        {
            var funcion = new DPagoFechaPago();
            var parametros = new MPagoFechaPago();
            parametros.IdFechaPago = IdFechaPago;
            await funcion.EliminarFechaPago(parametros);
            return NoContent();

        }
    }
}
