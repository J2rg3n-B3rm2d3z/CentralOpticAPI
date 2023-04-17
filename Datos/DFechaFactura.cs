using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DFechaFactura
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MFechaFactura>> MostrarFechaFacturas()
        {
            var lista = new List<MFechaFactura>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarFechaFacturas", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mfechafactura = new MFechaFactura();
                            mfechafactura.IdFechaFactura = (int)item["IdFechaFactura"];
                            mfechafactura.FechaEmision = (DateTime)item["FechaEmision"];
                            lista.Add(mfechafactura);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarFechaFactura(MFechaFactura parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarFechaFactura", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaEmision", parametros.FechaEmision);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarFechaFactura(MFechaFactura parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarFechaFactura", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdFechaFactura", parametros.IdFechaFactura);
                    cmd.Parameters.AddWithValue("@FechaEmision", parametros.FechaEmision);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarFechaFactura(MFechaFactura parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_eliminarFechaFactura", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdFechaFactura", parametros.IdFechaFactura);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
    }
}
