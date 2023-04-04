using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DNombreProducto
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MNombreProducto>> MostrarNombreProductos()
        {
            var lista = new List<MNombreProducto>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarNombreProductos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var nnombreproducto = new MNombreProducto();
                            nnombreproducto.IdNombreProducto = (int)item["IdNombreProducto"];
                            nnombreproducto.NombreProducto = (string)item["NombreProducto"];
                            lista.Add(nnombreproducto);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarNombreProducto(MNombreProducto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("insertarNombreProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreProducto", parametros.NombreProducto);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarNombreProducto(MNombreProducto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarNombreProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdNombreProducto", parametros.IdNombreProducto);
                    cmd.Parameters.AddWithValue("@NombreProducto", parametros.NombreProducto);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarNombreProducto(MNombreProducto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarNombreProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdNombreProducto", parametros.IdNombreProducto);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
    }
}
