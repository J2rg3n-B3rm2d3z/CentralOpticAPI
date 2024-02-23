using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;
using CentralOpticAPI.Controladores;

namespace CentralOpticAPI.Datos
{
    public class DFactura
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MFactura>> MostrarFacturas()
        {
            var lista = new List<MFactura>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarFacturas", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mfactura = new MFactura();
                            mfactura.NumFactura = (int)item["Numero_Factura"];
                            mfactura.Fecha_Emision = (DateTime)item["Fecha_Emision"];
                            mfactura.Estado_Factura = (string)item["Estado_Factura"];
                            mfactura.Tipo_Factura = (string)item["Tipo_Factura"];
                            mfactura.TipoVenta = (bool)item["TipoVenta"];
                            mfactura.Emisor = (string)item["Emisor"];
                            mfactura.Numero_Ruc = (string)item["Numero_Ruc"];
                            mfactura.Empresa_Asociada = (string)item["Empresa_Asociada"];
                            mfactura.Cliente = (string)item["Cliente"];
                            mfactura.Impuesto = (decimal)item["Impuesto"];
                            mfactura.Descuento = (decimal)item["Descuento"];

                            if (!item.IsDBNull(item.GetOrdinal("Subtotal")))
                                mfactura.Subtotal = (decimal)item["Subtotal"];
                            if (!item.IsDBNull(item.GetOrdinal("Total")))
                                mfactura.Total = (decimal)item["Total"];
                            if (!item.IsDBNull(item.GetOrdinal("Total_Pagado")))
                                mfactura.Total_Pagado = (decimal)item["Total_Pagado"];
                            if (!item.IsDBNull(item.GetOrdinal("Faltante")))
                                mfactura.Faltante = (decimal)item["Faltante"];
                            if (!item.IsDBNull(item.GetOrdinal("Descripcion_Credito")))
                                mfactura.Descripcion_Credito = (string)item["Descripcion_Credito"];
                            if (!item.IsDBNull(item.GetOrdinal("Paciente")))
                                mfactura.Paciente = (string)item["Paciente"];
                            if (!item.IsDBNull(item.GetOrdinal("Observacion")))
                                mfactura.Observacion = (string)item["Observacion"];

                            if (!item.IsDBNull(item.GetOrdinal("SPHIz")))
                                mfactura.SPHIz = (decimal)item["SPHIz"];
                            if (!item.IsDBNull(item.GetOrdinal("CYLIz")))
                                mfactura.CYLIz = (decimal)item["CYLIz"];
                            if (!item.IsDBNull(item.GetOrdinal("ADDIz")))
                                mfactura.ADDIz = (decimal)item["ADDIz"];
                            if (!item.IsDBNull(item.GetOrdinal("EJEIz")))
                                mfactura.EJEIz = (int)item["EJEIz"];
                            if (!item.IsDBNull(item.GetOrdinal("DPIz")))
                                mfactura.DPIz = (int)item["DPIz"];
                            if (!item.IsDBNull(item.GetOrdinal("ALTIz")))
                                mfactura.ALTIz = (int)item["ALTIz"];

                            if (!item.IsDBNull(item.GetOrdinal("SPHDe")))
                                mfactura.SPHDe = (decimal)item["SPHDe"];
                            if (!item.IsDBNull(item.GetOrdinal("CYLDe")))
                                mfactura.CYLDe = (decimal)item["CYLDe"];
                            if (!item.IsDBNull(item.GetOrdinal("ADDDe")))
                                mfactura.ADDDe = (decimal)item["ADDDe"];
                            if (!item.IsDBNull(item.GetOrdinal("EJEDe")))
                                mfactura.EJEDe = (int)item["EJEDe"];
                            if (!item.IsDBNull(item.GetOrdinal("DPDe")))
                                mfactura.DPDe = (int)item["DPDe"];
                            if (!item.IsDBNull(item.GetOrdinal("ALTDe")))
                                mfactura.ALTDe = (int)item["ALTDe"];

                            lista.Add(mfactura);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MFactura>> MostrarFacturasbyId(MFactura parametros)
        {
            var lista = new List<MFactura>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarFacturasById", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Numero_Factura", parametros.NumFactura);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mfactura = new MFactura();
                            mfactura.NumFactura = (int)item["Numero_Factura"];
                            mfactura.Fecha_Emision = (DateTime)item["Fecha_Emision"];
                            mfactura.Estado_Factura = (string)item["Estado_Factura"];
                            mfactura.Tipo_Factura = (string)item["Tipo_Factura"];
                            mfactura.TipoVenta = (bool)item["TipoVenta"];
                            mfactura.Emisor = (string)item["Emisor"];
                            mfactura.Numero_Ruc = (string)item["Numero_Ruc"];
                            mfactura.Empresa_Asociada = (string)item["Empresa_Asociada"];
                            mfactura.Cliente = (string)item["Cliente"];
                            mfactura.Impuesto = (decimal)item["Impuesto"];
                            mfactura.Descuento = (decimal)item["Descuento"];

                            if (!item.IsDBNull(item.GetOrdinal("Subtotal")))
                                mfactura.Subtotal = (decimal)item["Subtotal"];
                            if (!item.IsDBNull(item.GetOrdinal("Total")))
                                mfactura.Total = (decimal)item["Total"];
                            if (!item.IsDBNull(item.GetOrdinal("Total_Pagado")))
                                mfactura.Total_Pagado = (decimal)item["Total_Pagado"];
                            if (!item.IsDBNull(item.GetOrdinal("Faltante")))
                                mfactura.Faltante = (decimal)item["Faltante"]; ;
                            if (!item.IsDBNull(item.GetOrdinal("Descripcion_Credito")))
                                mfactura.Descripcion_Credito = (string)item["Descripcion_Credito"];
                            if (!item.IsDBNull(item.GetOrdinal("Paciente")))
                                mfactura.Paciente = (string)item["Paciente"];
                            if (!item.IsDBNull(item.GetOrdinal("Observacion")))
                                mfactura.Observacion = (string)item["Observacion"];

                            if (!item.IsDBNull(item.GetOrdinal("SPHIz")))
                                mfactura.SPHIz = (decimal)item["SPHIz"];
                            if (!item.IsDBNull(item.GetOrdinal("CYLIz")))
                                mfactura.CYLIz = (decimal)item["CYLIz"];
                            if (!item.IsDBNull(item.GetOrdinal("ADDIz")))
                                mfactura.ADDIz = (decimal)item["ADDIz"];
                            if (!item.IsDBNull(item.GetOrdinal("EJEIz")))
                                mfactura.EJEIz = (int)item["EJEIz"];
                            if (!item.IsDBNull(item.GetOrdinal("DPIz")))
                                mfactura.DPIz = (int)item["DPIz"];
                            if (!item.IsDBNull(item.GetOrdinal("ALTIz")))
                                mfactura.ALTIz = (int)item["ALTIz"];

                            if (!item.IsDBNull(item.GetOrdinal("SPHDe")))
                                mfactura.SPHDe = (decimal)item["SPHDe"];
                            if (!item.IsDBNull(item.GetOrdinal("CYLDe")))
                                mfactura.CYLDe = (decimal)item["CYLDe"];
                            if (!item.IsDBNull(item.GetOrdinal("ADDDe")))
                                mfactura.ADDDe = (decimal)item["ADDDe"];
                            if (!item.IsDBNull(item.GetOrdinal("EJEDe")))
                                mfactura.EJEDe = (int)item["EJEDe"];
                            if (!item.IsDBNull(item.GetOrdinal("DPDe")))
                                mfactura.DPDe = (int)item["DPDe"];
                            if (!item.IsDBNull(item.GetOrdinal("ALTDe")))
                                mfactura.ALTDe = (int)item["ALTDe"];

                            lista.Add(mfactura);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MFactura>> MostrarFacturasValidas(bool Estado)
        {
            var lista = new List<MFactura>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarFacturasValidos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Valido", Estado);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mfactura = new MFactura();
                            mfactura.NumFactura = (int)item["Numero_Factura"];
                            mfactura.Fecha_Emision = (DateTime)item["Fecha_Emision"];
                            mfactura.Estado_Factura = (string)item["Estado_Factura"];
                            mfactura.Tipo_Factura = (string)item["Tipo_Factura"];
                            mfactura.TipoVenta = (bool)item["TipoVenta"];
                            mfactura.Emisor = (string)item["Emisor"];
                            mfactura.Numero_Ruc = (string)item["Numero_Ruc"];
                            mfactura.Empresa_Asociada = (string)item["Empresa_Asociada"];
                            mfactura.Cliente = (string)item["Cliente"];
                            mfactura.Impuesto = (decimal)item["Impuesto"];
                            mfactura.Descuento = (decimal)item["Descuento"];

                            if (!item.IsDBNull(item.GetOrdinal("Subtotal")))
                                mfactura.Subtotal = (decimal)item["Subtotal"];
                            if (!item.IsDBNull(item.GetOrdinal("Total")))
                                mfactura.Total = (decimal)item["Total"];
                            if (!item.IsDBNull(item.GetOrdinal("Total_Pagado")))
                                mfactura.Total_Pagado = (decimal)item["Total_Pagado"];
                            if (!item.IsDBNull(item.GetOrdinal("Faltante")))
                                mfactura.Faltante = (decimal)item["Faltante"];
                            if (!item.IsDBNull(item.GetOrdinal("Descripcion_Credito")))
                                mfactura.Descripcion_Credito = (string)item["Descripcion_Credito"];
                            if (!item.IsDBNull(item.GetOrdinal("Paciente")))
                                mfactura.Paciente = (string)item["Paciente"];
                            if (!item.IsDBNull(item.GetOrdinal("Observacion")))
                                mfactura.Observacion = (string)item["Observacion"];

                            if (!item.IsDBNull(item.GetOrdinal("SPHIz")))
                                mfactura.SPHIz = (decimal)item["SPHIz"];
                            if (!item.IsDBNull(item.GetOrdinal("CYLIz")))
                                mfactura.CYLIz = (decimal)item["CYLIz"];
                            if (!item.IsDBNull(item.GetOrdinal("ADDIz")))
                                mfactura.ADDIz = (decimal)item["ADDIz"];
                            if (!item.IsDBNull(item.GetOrdinal("EJEIz")))
                                mfactura.EJEIz = (int)item["EJEIz"];
                            if (!item.IsDBNull(item.GetOrdinal("DPIz")))
                                mfactura.DPIz = (int)item["DPIz"];
                            if (!item.IsDBNull(item.GetOrdinal("ALTIz")))
                                mfactura.ALTIz = (int)item["ALTIz"];

                            if (!item.IsDBNull(item.GetOrdinal("SPHDe")))
                                mfactura.SPHDe = (decimal)item["SPHDe"];
                            if (!item.IsDBNull(item.GetOrdinal("CYLDe")))
                                mfactura.CYLDe = (decimal)item["CYLDe"];
                            if (!item.IsDBNull(item.GetOrdinal("ADDDe")))
                                mfactura.ADDDe = (decimal)item["ADDDe"];
                            if (!item.IsDBNull(item.GetOrdinal("EJEDe")))
                                mfactura.EJEDe = (int)item["EJEDe"];
                            if (!item.IsDBNull(item.GetOrdinal("DPDe")))
                                mfactura.DPDe = (int)item["DPDe"];
                            if (!item.IsDBNull(item.GetOrdinal("ALTDe")))
                                mfactura.ALTDe = (int)item["ALTDe"];

                            lista.Add(mfactura);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarFactura(MFacturaIngreso parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarFactura", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EstadoFactura", parametros.Estado_Factura);
                    cmd.Parameters.AddWithValue("@TipoFactura", parametros.Tipo_Factura);
                    cmd.Parameters.AddWithValue("@NumeroEmpleado", parametros.NumeroEmpleado);
                    cmd.Parameters.AddWithValue("@CodigoCliente", parametros.Codigo_Cliente);
                    cmd.Parameters.AddWithValue("@NumeroExamen", SqlDbType.Int).Value = (object)parametros.NumExamen ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@TipoVenta", parametros.TipoVenta);
                    cmd.Parameters.AddWithValue("@Impuesto", parametros.Impuesto);
                    cmd.Parameters.AddWithValue("@Descuento", parametros.Descuento);
                    cmd.Parameters.AddWithValue("@FechaEmision", parametros.Fecha_Emision);
                    cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.NVarChar).Value = (object)parametros.Descripcion_Credito ?? DBNull.Value;

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
        public async Task EditarFactura(MFacturaIngreso parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarEstadoFactura", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NumeroFactura", parametros.NumFactura);
                    cmd.Parameters.AddWithValue("@EstadoFactura", parametros.Estado_Factura);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        //public async Task EliminarFactura(MFactura parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_eliminarFactura", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@NumFactura", parametros.NumFactura);
        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}
    }
}
