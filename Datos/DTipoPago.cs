using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DTipoPago
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MTipoPago>> MostrarTipoPago()
        {
            var lista = new List<MTipoPago>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarTipoPago", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mTipoPago = new MTipoPago();
                            mTipoPago.Id_TipoPago = (int)item["Id_TipoPago"];
                            mTipoPago.Tipo_Pago = (string)item["Tipo_Pago"];
                            lista.Add(mTipoPago);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MTipoPago>> MostrarTipoPagoById(MTipoPago parametros)
        {
            var lista = new List<MTipoPago>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarTipoPagoById", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_TipoPago", parametros.Id_TipoPago);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mPagoFechaPago = new MTipoPago();
                            mPagoFechaPago.Id_TipoPago = (int)item["Id_TipoPago"];
                            mPagoFechaPago.Tipo_Pago = (string)item["Tipo_Pago"];
                            lista.Add(mPagoFechaPago);
                        }
                    }
                }
            }
            return lista;
        }

        //public async Task InsertarFechaPago(MTipoPago parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_insertarFechaPago", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@FechaPago", parametros.FechaPago);

        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}

        //public async Task EditarFechaPago(MTipoPago parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_editarFechaPago", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@IdFechaPago", parametros.IdFechaPago);
        //            cmd.Parameters.AddWithValue("@FechaPago", parametros.FechaPago);

        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}

        //public async Task EliminarFechaPago(MTipoPago parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_eliminarFechaPago", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@IdFechaPago", parametros.IdFechaPago);
        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}
    }
}
