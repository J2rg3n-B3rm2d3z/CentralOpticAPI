using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DPagoFechaPago
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MPagoFechaPago>> MostrarFechaObtencion()
        {
            var lista = new List<MPagoFechaPago>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarFechaPago", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mPagoFechaPago = new MPagoFechaPago();
                            mPagoFechaPago.IdFechaPago = (int)item["IdFechaPago"];
                            mPagoFechaPago.FechaPago = (DateTime)item["FechaPago"];
                            lista.Add(mPagoFechaPago);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarFechaPago(MPagoFechaPago parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarFechaPago", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaPago", parametros.FechaPago);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarFechaPago(MPagoFechaPago parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarFechaPago", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdFechaPago", parametros.IdFechaPago);
                    cmd.Parameters.AddWithValue("@FechaPago", parametros.FechaPago);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarFechaPago(MPagoFechaPago parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_eliminarFechaPago", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdFechaPago", parametros.IdFechaPago);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
    }
}
