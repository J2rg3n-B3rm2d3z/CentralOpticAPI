using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DTipoFactura
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MTipoFactura>> MostrarTipoFacturas()
        {
            var lista = new List<MTipoFactura>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarTipoFactura", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mtipofactura = new MTipoFactura();
                            mtipofactura.Id_TipoFactura = (int)item["Id_TipoFactura"];
                            mtipofactura.Tipo_Factura = (string)item["Tipo_Factura"];
                            lista.Add(mtipofactura);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MTipoFactura>> MostrarTipoFacturasById(MTipoFactura parametros)
        {
            var lista = new List<MTipoFactura>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarTipoFacturaById", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_TipoFactura", parametros.Id_TipoFactura);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mtipofactura = new MTipoFactura();
                            mtipofactura.Id_TipoFactura = (int)item["Id_TipoFactura"];
                            mtipofactura.Tipo_Factura = (string)item["Tipo_Factura"];
                            lista.Add(mtipofactura);
                        }
                    }
                }
            }
            return lista;
        }

        //public async Task InsertarFechaFactura(MTipoFactura parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_insertarFechaFactura", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@FechaEmision", parametros.FechaEmision);

        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}

        //public async Task EditarFechaFactura(MTipoFactura parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_editarFechaFactura", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@IdFechaFactura", parametros.IdFechaFactura);
        //            cmd.Parameters.AddWithValue("@FechaEmision", parametros.FechaEmision);

        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}

        //public async Task EliminarFechaFactura(MTipoFactura parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_eliminarFechaFactura", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@IdFechaFactura", parametros.IdFechaFactura);
        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}
    }
}
