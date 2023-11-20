using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DTipoProducto
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MTipoProducto>> MostrarTipoProducto()
        {
            var lista = new List<MTipoProducto>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarTipoProducto", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mtipoproducto = new MTipoProducto();
                            mtipoproducto.Id_TipoProducto = (string)item["Id_TipoProducto"];
                            mtipoproducto.TipoProducto = (string)item["Tipo_Producto"];
                            lista.Add(mtipoproducto);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MTipoProducto>> MostrarTipoProductoById(MTipoProducto parametros)
        {
            var lista = new List<MTipoProducto>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarTipoProductoById", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_TipoProducto", parametros.Id_TipoProducto);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mtipoproducto = new MTipoProducto();
                            mtipoproducto.Id_TipoProducto = (string)item["Id_TipoProducto"];
                            mtipoproducto.TipoProducto = (string)item["Tipo_Producto"];
                            lista.Add(mtipoproducto);
                        }
                    }
                }
            }
            return lista;
        }

        //public async Task InsertarMarca(MTipoProducto parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_insertarMarca", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@Marca", parametros.Marca);

        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}

        //public async Task EditarMarca(MTipoProducto parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_editarMarca", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@IdMarca", parametros.IdMarca);
        //            cmd.Parameters.AddWithValue("@Marca", parametros.Marca);

        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}

        //public async Task EliminarMarca(MTipoProducto parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_eliminarMarca", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@IdMarca", parametros.IdMarca);
        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}
    }
}
