using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DProducto
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MProducto>> MostrarProductos()
        {
            var lista = new List<MProducto>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarProducto", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mproducto = new MProducto();
                            mproducto.CodProducto = (int)item["CodProducto"];
                            mproducto.IdMarca = (int)item["IdMarca"];
                            mproducto.IdNombreProducto = (int)item["IdNombreProducto"];
                            mproducto.Descripcion = (string)item["Descripcion"];
                            mproducto.PrecioActual = (decimal)item["PrecioActual"];
                            mproducto.EstadoProducto = (bool)item["EstadoProducto"];
                            lista.Add(mproducto);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarProducto(MProducto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdMarca", parametros.IdMarca);
                    cmd.Parameters.AddWithValue("@IdNombreProducto", parametros.IdNombreProducto);
                    cmd.Parameters.AddWithValue("@Descripcion", parametros.Descripcion);
                    cmd.Parameters.AddWithValue("@PrecioActual", parametros.PrecioActual);
                    cmd.Parameters.AddWithValue("@EstadoProducto", parametros.EstadoProducto);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarProducto(MProducto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CodProducto", parametros.CodProducto);
                    cmd.Parameters.AddWithValue("@IdMarca", parametros.IdMarca);
                    cmd.Parameters.AddWithValue("@IdNombreProducto", parametros.IdNombreProducto);
                    cmd.Parameters.AddWithValue("@Descripcion", parametros.Descripcion);
                    cmd.Parameters.AddWithValue("@PrecioActual", parametros.PrecioActual);
                    cmd.Parameters.AddWithValue("@EstadoProducto", parametros.EstadoProducto);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarProducto(MProducto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_eliminarProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CodProducto", parametros.CodProducto);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
    }
}
