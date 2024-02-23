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
                            mproducto.CodProducto = (string)item["Codigo_Producto"];
                            mproducto.Descripcion = (string)item["Descripcion"];
                            mproducto.TipoProducto = (string)item["Tipo_Producto"];
                            mproducto.Estado = (bool)item["Estado"];
                            mproducto.PrecioVenta = (decimal)item["Precio_Venta"];
                            mproducto.PrecioCompra = (decimal)item["Precio_Compra"];
                            mproducto.Cantidad = (int)item["Cantidad"];
                            mproducto.StockMinimo = (int)item["Stock_Minimo"];
                            mproducto.StockMaximo = (int)item["Stock_Maximo"];
                            lista.Add(mproducto);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MProducto>> MostrarProductosbyId(MProducto parametros)
        {
            var lista = new List<MProducto>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarProductobyId", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo_Producto", parametros.CodProducto);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mproducto = new MProducto();
                            mproducto.CodProducto = (string)item["Codigo_Producto"];
                            mproducto.Descripcion = (string)item["Descripcion"];
                            mproducto.TipoProducto = (string)item["Tipo_Producto"];
                            mproducto.Estado = (bool)item["Estado"];
                            mproducto.PrecioVenta = (decimal)item["Precio_Venta"];
                            mproducto.PrecioCompra = (decimal)item["Precio_Compra"];
                            mproducto.Cantidad = (int)item["Cantidad"];
                            mproducto.StockMinimo = (int)item["Stock_Minimo"];
                            mproducto.StockMaximo = (int)item["Stock_Maximo"];
                            lista.Add(mproducto);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MProducto>> MostrarProductosActivos(MProducto parametros)
        {
            var lista = new List<MProducto>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarProductoActivos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Estado", parametros.Estado);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mproducto = new MProducto();
                            mproducto.CodProducto = (string)item["Codigo_Producto"];
                            mproducto.Descripcion = (string)item["Descripcion"];
                            mproducto.TipoProducto = (string)item["Tipo_Producto"];
                            mproducto.Estado = (bool)item["Estado"];
                            mproducto.PrecioVenta = (decimal)item["Precio_Venta"];
                            mproducto.PrecioCompra = (decimal)item["Precio_Compra"];
                            mproducto.Cantidad = (int)item["Cantidad"];
                            mproducto.StockMinimo = (int)item["Stock_Minimo"];
                            mproducto.StockMaximo = (int)item["Stock_Maximo"];
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
                using (var cmd = new SqlCommand("SP_InsetarProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Tipo_Producto", parametros.TipoProducto);
                    cmd.Parameters.AddWithValue("@Descripcion", parametros.Descripcion);
                    cmd.Parameters.AddWithValue("@Precio_Venta", parametros.PrecioVenta);
                    cmd.Parameters.AddWithValue("@Precio_Compra", parametros.PrecioCompra);
                    cmd.Parameters.AddWithValue("@Stock_Minimo", parametros.StockMinimo);
                    cmd.Parameters.AddWithValue("@Stock_Maximo", parametros.StockMaximo);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarProducto(MProducto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EditarProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Codigo_Producto", parametros.CodProducto);
                    cmd.Parameters.AddWithValue("@Tipo_Producto", parametros.TipoProducto);
                    cmd.Parameters.AddWithValue("@Descripcion", parametros.Descripcion);
                    cmd.Parameters.AddWithValue("@Estado", parametros.Estado);
                    cmd.Parameters.AddWithValue("@Precio_Venta", parametros.PrecioVenta);
                    cmd.Parameters.AddWithValue("@Precio_Compra", parametros.PrecioCompra);
                    cmd.Parameters.AddWithValue("@Stock_Minimo", parametros.StockMinimo);
                    cmd.Parameters.AddWithValue("@Stock_Maximo", parametros.StockMaximo);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        //public async Task EliminarProducto(MProducto parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_eliminarProducto", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@CodProducto", parametros.CodProducto);
        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}
    }
}
