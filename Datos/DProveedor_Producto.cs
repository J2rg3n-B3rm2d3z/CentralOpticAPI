using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DProveedor_Producto
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MProveedor_Producto>> MostrarProveedor_Productos()
        {
            var lista = new List<MProveedor_Producto>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarProveedor_Productos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mproveedor_producto = new MProveedor_Producto();
                            mproveedor_producto.IdProveedor_Producto = (int)item["IdProveedor_Producto"];
                            mproveedor_producto.IdProveedor = (int)item["IdProveedor"];
                            mproveedor_producto.CodProducto = (int)item["CodProducto"];
                            mproveedor_producto.IdFechaObtencion = (int)item["IdFechaObtencion"];
                            mproveedor_producto.Cantidad = (int)item["Cantidad"];
                            mproveedor_producto.Costo = (decimal)item["Costo"];
                            lista.Add(mproveedor_producto);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarProveedor_Producto(MProveedor_Producto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarProveedor_Producto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProveedor", parametros.IdProveedor);
                    cmd.Parameters.AddWithValue("@CodProducto", parametros.CodProducto);
                    cmd.Parameters.AddWithValue("@IdFechaObtencion", parametros.IdFechaObtencion);
                    cmd.Parameters.AddWithValue("@Cantidad", parametros.Cantidad);
                    cmd.Parameters.AddWithValue("@Costo", parametros.Costo);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarProveedor_Producto(MProveedor_Producto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarProveedor_Producto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdProveedor_Producto", parametros.IdProveedor_Producto);
                    cmd.Parameters.AddWithValue("@IdProveedor", parametros.IdProveedor);
                    cmd.Parameters.AddWithValue("@CodProducto", parametros.CodProducto);
                    cmd.Parameters.AddWithValue("@IdFechaObtencion", parametros.IdFechaObtencion);
                    cmd.Parameters.AddWithValue("@Cantidad", parametros.Cantidad);
                    cmd.Parameters.AddWithValue("@Costo", parametros.Costo);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarProveedor_Producto(MProveedor_Producto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_eliminarProveedor_Producto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdProveedor_Producto", parametros.IdProveedor_Producto);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
    }
}
