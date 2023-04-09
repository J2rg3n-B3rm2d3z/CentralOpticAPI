using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DPago
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MPago>> MostrarPago()
        {
            var lista = new List<MPago>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarPago", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mPago = new MPago();
                            mPago.IdPago = (int)item["IdPago"];
                            mPago.NumFactura = (int)item["NumFactura"];
                            mPago.IdFechaPago = (int)item["IdFechaPago"];
                            mPago.Monto = (decimal)item["Monto"];
                            mPago.TipoPago = (bool)item["TipoPago"];
                            lista.Add(mPago);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarPago(MPago parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("insertarPago", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NumFactura", parametros.NumFactura);
                    cmd.Parameters.AddWithValue("@IdFechaPago", parametros.IdFechaPago);
                    cmd.Parameters.AddWithValue("@Monto", parametros.Monto);
                    cmd.Parameters.AddWithValue("@TipoPago", parametros.TipoPago);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarPago(MPago parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarPago", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdPago", parametros.IdPago);
                    cmd.Parameters.AddWithValue("@NumFactura", parametros.NumFactura);
                    cmd.Parameters.AddWithValue("@IdFechaPago", parametros.IdFechaPago);
                    cmd.Parameters.AddWithValue("@Monto", parametros.Monto);
                    cmd.Parameters.AddWithValue("@TipoPago", parametros.TipoPago);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarPago(MPago parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarPago", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdPago", parametros.IdPago);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
    }
}
