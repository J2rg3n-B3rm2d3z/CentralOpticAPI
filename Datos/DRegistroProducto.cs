using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DRegistroProducto
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MRegistroProducto>> MostrarRegistroProducto()
        {
            var lista = new List<MRegistroProducto>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarRegistroProducto", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mregistroproducto = new MRegistroProducto();
                            mregistroproducto.CodigoProducto = (string)item["Codigo_Producto"];
                            mregistroproducto.Descripcion = (string)item["Descripcion"];
                            mregistroproducto.NombreEmpresa = (string)item["Nombre_Empresa"];
                            mregistroproducto.FechaAdquisicion = (DateTime)item["Fecha_Adquisicion"];
                            mregistroproducto.Cantidad = (int)item["Cantidad"];
                            mregistroproducto.Costo = (decimal)item["Costo"];
                            mregistroproducto.Estado = (bool)item["Estado"];
                            lista.Add(mregistroproducto);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MRegistroProducto>> MostrarRegistroProductoValidos(MRegistroProducto parametros)
        {
            var lista = new List<MRegistroProducto>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarRegistroProductoValido", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Valido", parametros.Estado);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mregistroproducto = new MRegistroProducto();
                            mregistroproducto.CodigoProducto = (string)item["Codigo_Producto"];
                            mregistroproducto.Descripcion = (string)item["Descripcion"];
                            mregistroproducto.NombreEmpresa = (string)item["Nombre_Empresa"];
                            mregistroproducto.FechaAdquisicion = (DateTime)item["Fecha_Adquisicion"];
                            mregistroproducto.Cantidad = (int)item["Cantidad"];
                            mregistroproducto.Costo = (decimal)item["Costo"];
                            mregistroproducto.Estado = (bool)item["Estado"];
                            lista.Add(mregistroproducto);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarRegistroProducto(MRegistroProducto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarRegistroProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DescripcionP", parametros.Descripcion);
                    cmd.Parameters.AddWithValue("@Nombre_Empresa", parametros.NombreEmpresa);
                    cmd.Parameters.AddWithValue("@Fecha_Adquisicion", parametros.FechaAdquisicion);
                    cmd.Parameters.AddWithValue("@Cantidad", parametros.Cantidad);
                    cmd.Parameters.AddWithValue("@Costo", parametros.Costo);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarRegistroProducto(MRegistroProducto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarRegistroProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DescripcionP", parametros.Descripcion);
                    cmd.Parameters.AddWithValue("@Nombre_Empresa", parametros.NombreEmpresa);
                    cmd.Parameters.AddWithValue("@Fecha_Adquisicion", parametros.FechaAdquisicion);
                    cmd.Parameters.AddWithValue("@Cantidad", parametros.Cantidad);
                    cmd.Parameters.AddWithValue("@Costo", parametros.Costo);
                    cmd.Parameters.AddWithValue("@Estado", parametros.Estado);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        //public async Task EliminarProveedor_Producto(MRegistroProducto parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_eliminarProveedor_Producto", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@IdProveedor_Producto", parametros.IdProveedor_Producto);
        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}
    }
}
