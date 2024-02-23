using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;
using CentralOpticAPI.Controladores;

namespace CentralOpticAPI.Datos
{
    public class DPago
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MPago>> MostrarPago()
        {
            var lista = new List<MPago>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarPago", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mPago = new MPago();
                            mPago.Id_Pago = (int)item["Id_Pago"];
                            mPago.Estado = (bool)item["Estado"];
                            mPago.Numero_Factura = (int)item["Numero_Factura"];
                            mPago.Estado_Factura = (string)item["Estado_Factura"];
                            mPago.Tipo_Factura = (string)item["Tipo_Factura"];
                            mPago.Cliente_Factura = (string)item["Cliente_Factura"];
                            mPago.Tipo_Pago = (string)item["Tipo_Pago"];
                            mPago.Abono = (decimal)item["Abono"];
                            mPago.Fecha_Pago = (DateTime)item["Fecha_Pago"];
                            if (!item.IsDBNull(item.GetOrdinal("Descripcion")))
                                mPago.Descripcion = (string)item["Descripcion"];

                            lista.Add(mPago);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MPago>> MostrarPagoById(MPago parametros)
        {
            var lista = new List<MPago>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarPagoById", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Pago", parametros.Id_Pago);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mPago = new MPago();
                            mPago.Id_Pago = (int)item["Id_Pago"];
                            mPago.Estado = (bool)item["Estado"];
                            mPago.Numero_Factura = (int)item["Numero_Factura"];
                            mPago.Estado_Factura = (string)item["Estado_Factura"];
                            mPago.Tipo_Factura = (string)item["Tipo_Factura"];
                            mPago.Cliente_Factura = (string)item["Cliente_Factura"];
                            mPago.Tipo_Pago = (string)item["Tipo_Pago"];
                            mPago.Abono = (decimal)item["Abono"];
                            mPago.Fecha_Pago = (DateTime)item["Fecha_Pago"];
                            if (!item.IsDBNull(item.GetOrdinal("Descripcion")))
                                mPago.Descripcion = (string)item["Descripcion"];
                            lista.Add(mPago);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MPago>> MostrarPagoByFactura(MPago parametros)
        {
            var lista = new List<MPago>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarPagoByFactura", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Numero_Factura", parametros.Numero_Factura);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mPago = new MPago();
                            mPago.Id_Pago = (int)item["Id_Pago"];
                            mPago.Estado = (bool)item["Estado"];
                            mPago.Numero_Factura = (int)item["Numero_Factura"];
                            mPago.Estado_Factura = (string)item["Estado_Factura"];
                            mPago.Tipo_Factura = (string)item["Tipo_Factura"];
                            mPago.Cliente_Factura = (string)item["Cliente_Factura"];
                            mPago.Tipo_Pago = (string)item["Tipo_Pago"];
                            mPago.Abono = (decimal)item["Abono"];
                            mPago.Fecha_Pago = (DateTime)item["Fecha_Pago"];
                            if (!item.IsDBNull(item.GetOrdinal("Descripcion")))
                                mPago.Descripcion = (string)item["Descripcion"];
                            lista.Add(mPago);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MPago>> MostrarPagoValido(MPago parametros)
        {
            var lista = new List<MPago>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarPagoValido", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Estado", parametros.Estado);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mPago = new MPago();
                            mPago.Id_Pago = (int)item["Id_Pago"];
                            mPago.Estado = (bool)item["Estado"];
                            mPago.Numero_Factura = (int)item["Numero_Factura"];
                            mPago.Estado_Factura = (string)item["Estado_Factura"];
                            mPago.Tipo_Factura = (string)item["Tipo_Factura"];
                            mPago.Cliente_Factura = (string)item["Cliente_Factura"];
                            mPago.Tipo_Pago = (string)item["Tipo_Pago"];
                            mPago.Abono = (decimal)item["Abono"];
                            mPago.Fecha_Pago = (DateTime)item["Fecha_Pago"];
                            if (!item.IsDBNull(item.GetOrdinal("Descripcion")))
                                mPago.Descripcion = (string)item["Descripcion"];
                            lista.Add(mPago);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarPago(MPago parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarPago", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NumeroFactura", parametros.Numero_Factura);
                    cmd.Parameters.AddWithValue("@Tipo_Pago", parametros.Tipo_Pago);
                    cmd.Parameters.AddWithValue("@Abono", parametros.Abono);
                    cmd.Parameters.AddWithValue("@Fecha_Pago", parametros.Fecha_Pago);
                    cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.NVarChar).Value = (object)parametros.Descripcion ?? DBNull.Value;

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarPago(MPago parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarEstadoPago", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id_Pago", parametros.Id_Pago);
                    cmd.Parameters.AddWithValue("@Estado", parametros.Estado);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        //public async Task EliminarPago(MPago parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_eliminarPago", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@IdPago", parametros.IdPago);
        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}
    }
}
