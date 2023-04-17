using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DDetalleFactura
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MDetalleFactura>> MostrarDetalleFacturas()
        {
            var lista = new List<MDetalleFactura>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarDetalleFacturas", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mdetallefactura = new MDetalleFactura();
                            mdetallefactura.IdDetalleFactura = (int)item["IdDetalleFactura"];
                            mdetallefactura.NumFactura = (int)item["NumFactura"];
                            mdetallefactura.CodProducto = (int)item["CodProducto"];
                            mdetallefactura.Cantidad = (int)item["Cantidad"];
                            mdetallefactura.PrecioUni = (decimal)item["PrecioUni"];
                            lista.Add(mdetallefactura);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarDetalleFactura(MDetalleFactura parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarDetalleFactura", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NumFactura", parametros.NumFactura);
                    cmd.Parameters.AddWithValue("@CodProducto", parametros.CodProducto);
                    cmd.Parameters.AddWithValue("@Cantidad", parametros.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioUni", parametros.PrecioUni);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarDetalleFactura(MDetalleFactura parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarDetalleFactura", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdDetalleFactura", parametros.IdDetalleFactura);
                    cmd.Parameters.AddWithValue("@NumFactura", parametros.NumFactura);
                    cmd.Parameters.AddWithValue("@CodProducto", parametros.CodProducto);
                    cmd.Parameters.AddWithValue("@Cantidad", parametros.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioUni", parametros.PrecioUni);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarDetalleFactura(MDetalleFactura parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_eliminarDetalleFactura", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdDetalleFactura", parametros.IdDetalleFactura);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
    }
}
