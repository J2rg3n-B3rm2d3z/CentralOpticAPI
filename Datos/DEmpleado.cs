using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DEmpleado
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MEmpleado>> MostrarEmpleado()
        {
            var lista = new List<MEmpleado>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarEmpleado", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEmpleado = new MEmpleado();
                            mEmpleado.NumEmpleado = (int)item["NumEmpleado"];
                            mEmpleado.Nombres = (string)item["Nombres"];
                            mEmpleado.Apellidos = (string)item["Apellidos"];
                            mEmpleado.Direccion = (string)item["Direccion"];
                            lista.Add(mEmpleado);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarEmpleado(MEmpleado parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarEmpleado", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombres", parametros.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", parametros.Apellidos);
                    cmd.Parameters.AddWithValue("@Direccion", parametros.Direccion);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarEmpleado(MEmpleado parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarEmpleado", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NumEmpleado", parametros.NumEmpleado);
                    cmd.Parameters.AddWithValue("@Nombres", parametros.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", parametros.Apellidos);
                    cmd.Parameters.AddWithValue("@Direccion", parametros.Direccion);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarEmpleado(MEmpleado parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_eliminarEmpleado", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NumEmpleado", parametros.NumEmpleado);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

    }
}

