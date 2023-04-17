using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DBodega
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MBodega>> MostrarBodegas()
        {
            var lista = new List<MBodega>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarBodegas", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mbodega = new MBodega();
                            mbodega.IdBodega = (int)item["IdBodega"];
                            mbodega.Nombre = (string)item["Nombre"];
                            mbodega.Direccion = (string)item["Direccion"];
                            if (!item.IsDBNull(item.GetOrdinal("Telefono")))
                                mbodega.Telefono = (string)item["Telefono"];
                            if (!item.IsDBNull(item.GetOrdinal("Correo")))
                                mbodega.Correo = (string)item["Correo"];

                            lista.Add(mbodega);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarBodega(MBodega parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarBodega", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", parametros.Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", parametros.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", SqlDbType.NChar).Value = (object)parametros.Telefono ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@Correo", SqlDbType.NVarChar).Value = (object)parametros.Correo ?? DBNull.Value;

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarBodega(MBodega parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarBodega", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdBodega", parametros.IdBodega);
                    cmd.Parameters.AddWithValue("@Nombre", parametros.Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", parametros.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", SqlDbType.NChar).Value = (object)parametros.Telefono ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@Correo", SqlDbType.NVarChar).Value = (object)parametros.Correo ?? DBNull.Value;

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarBodega(MBodega parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_eliminarBodega", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdBodega", parametros.IdBodega);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
    }
}
