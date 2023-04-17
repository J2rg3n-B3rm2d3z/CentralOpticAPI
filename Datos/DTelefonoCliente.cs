using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DTelefonoCliente
    {
        ConexionBD cn = new ConexionBD();

        public async Task<List<MTelefonoCliente>> MostrarTelefonoClientes()
        {
            var lista = new List<MTelefonoCliente>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarTelefonoCliente", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mtelefonocliente = new MTelefonoCliente();
                            mtelefonocliente.IdTelefonoCliente = (int)item["IdTelefonoCliente"];
                            mtelefonocliente.CodCliente = (int)item["CodCliente"];
                            mtelefonocliente.Telefono = (string)item["Telefono"];
                            lista.Add(mtelefonocliente);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarTelefonoCliente(MTelefonoCliente parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarTelefonoCliente", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CodCliente", parametros.CodCliente);
                    cmd.Parameters.AddWithValue("@Telefono", parametros.Telefono);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarTelefonoCliente(MTelefonoCliente parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarTelefonoCliente", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdTelefonoCliente", parametros.IdTelefonoCliente);
                    cmd.Parameters.AddWithValue("@CodCliente", parametros.CodCliente);
                    cmd.Parameters.AddWithValue("@Telefono", parametros.Telefono);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarTelefonoCliente(MTelefonoCliente parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_eliminarTelefonoCliente", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdTelefonoCliente", parametros.IdTelefonoCliente);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

    }
}
