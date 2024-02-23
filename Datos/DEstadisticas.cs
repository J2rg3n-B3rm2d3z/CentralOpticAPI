using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;
using CentralOpticAPI.Controladores;

namespace CentralOpticAPI.Datos
{
    public class DEstadisticas
    {
        ConexionBD cn = new ConexionBD();

        //
        public async Task<List<MEstClienteRecurrente>> EstClientesMasRecurrentes(MEstadisticas parametros)
        {
            var lista = new List<MEstClienteRecurrente>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EstClientesMasRecurrentes", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", parametros.FechaInicial);
                    cmd.Parameters.AddWithValue("@Fecha_Final", parametros.FechaFinal);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEstClienteRecurrente = new MEstClienteRecurrente();
                            if (!item.IsDBNull(item.GetOrdinal("Cedula")))
                                mEstClienteRecurrente.Cedula = (string)item["Cedula"];
                            mEstClienteRecurrente.Cliente = (string)item["Cliente"];
                            mEstClienteRecurrente.Veces_Facturadas = (int)item["Veces_Facturadas"];
                            
                            lista.Add(mEstClienteRecurrente);
                        }
                    }
                }
            }

            return lista;
        }

        //
        public async Task<List<MEstProductoVendido>> EstProductosMasVendidos(MEstadisticas parametros)
        {
            var lista = new List<MEstProductoVendido>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EstProductosMasVendidos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", parametros.FechaInicial);
                    cmd.Parameters.AddWithValue("@Fecha_Final", parametros.FechaFinal);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEstProductoVendido = new MEstProductoVendido();
                            mEstProductoVendido.Codigo_Producto = (string)item["Codigo_Producto"];
                            mEstProductoVendido.Descripcion = (string)item["Descripcion"];
                            mEstProductoVendido.Tipo_Producto = (string)item["Tipo_Producto"];
                            mEstProductoVendido.Total = (int)item["Total"];

                            lista.Add(mEstProductoVendido);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MEstProductoVendido>> EstProductosMenosVendidos(MEstadisticas parametros)
        {
            var lista = new List<MEstProductoVendido>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EstProductosMenosVendidos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", parametros.FechaInicial);
                    cmd.Parameters.AddWithValue("@Fecha_Final", parametros.FechaFinal);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEstProductoVendido = new MEstProductoVendido();
                            mEstProductoVendido.Codigo_Producto = (string)item["Codigo_Producto"];
                            mEstProductoVendido.Descripcion = (string)item["Descripcion"];
                            mEstProductoVendido.Tipo_Producto = (string)item["Tipo_Producto"];
                            mEstProductoVendido.Total = (int)item["Total"];

                            lista.Add(mEstProductoVendido);
                        }
                    }
                }
            }
            return lista;
        }

        //
        public async Task<List<MEstProveedorRecurrente>> EstProveedoresMasRecurrentes(MEstadisticas parametros)
        {
            var lista = new List<MEstProveedorRecurrente>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EstProveedoresMasRecurrentes", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", parametros.FechaInicial);
                    cmd.Parameters.AddWithValue("@Fecha_Final", parametros.FechaFinal);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEstProveedorRecurrente = new MEstProveedorRecurrente();
                            mEstProveedorRecurrente.Codigo_Proveedor = (int)item["Codigo_Proveedor"];
                            mEstProveedorRecurrente.Nombre_Empresa = (string)item["Nombre_Empresa"];
                            mEstProveedorRecurrente.Total_Productos = (int)item["Total_Productos"];

                            lista.Add(mEstProveedorRecurrente);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MEstProveedorRecurrente>> EstProveedoresMenosRecurrentes(MEstadisticas parametros)
        {
            var lista = new List<MEstProveedorRecurrente>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EstProveedoresMenosRecurrentes", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", parametros.FechaInicial);
                    cmd.Parameters.AddWithValue("@Fecha_Final", parametros.FechaFinal);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEstProveedorRecurrente = new MEstProveedorRecurrente();
                            mEstProveedorRecurrente.Codigo_Proveedor = (int)item["Codigo_Proveedor"];
                            mEstProveedorRecurrente.Nombre_Empresa = (string)item["Nombre_Empresa"];
                            mEstProveedorRecurrente.Total_Productos = (int)item["Total_Productos"];

                            lista.Add(mEstProveedorRecurrente);
                        }
                    }
                }
            }
            return lista;
        }

        //

        public async Task<List<MEstProductoAdquirido>> EstProductosMasAdquiridos(MEstadisticas parametros)
        {
            var lista = new List<MEstProductoAdquirido>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EstProductosMasAdquiridos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", parametros.FechaInicial);
                    cmd.Parameters.AddWithValue("@Fecha_Final", parametros.FechaFinal);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEstProductoAdquirido = new MEstProductoAdquirido();
                            mEstProductoAdquirido.Codigo_Producto = (string)item["Codigo_Producto"];
                            mEstProductoAdquirido.Descripcion = (string)item["Descripcion"];
                            mEstProductoAdquirido.Tipo_Producto = (string)item["Tipo_Producto"];
                            mEstProductoAdquirido.Total_Productos = (int)item["Total_Productos"];

                            lista.Add(mEstProductoAdquirido);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MEstProductoAdquirido>> EstProductosMenosAdquiridos(MEstadisticas parametros)
        {
            var lista = new List<MEstProductoAdquirido>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EstProductosMenosAdquiridos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", parametros.FechaInicial);
                    cmd.Parameters.AddWithValue("@Fecha_Final", parametros.FechaFinal);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEstProductoAdquirido = new MEstProductoAdquirido();
                            mEstProductoAdquirido.Codigo_Producto = (string)item["Codigo_Producto"];
                            mEstProductoAdquirido.Descripcion = (string)item["Descripcion"];
                            mEstProductoAdquirido.Tipo_Producto = (string)item["Tipo_Producto"];
                            mEstProductoAdquirido.Total_Productos = (int)item["Total_Productos"];

                            lista.Add(mEstProductoAdquirido);
                        }
                    }
                }
            }
            return lista;
        }

        //

        public async Task<List<MEstLaboratorioRecurrente>> EstLaboratoriosMasRecurrentes(MEstadisticas parametros)
        {
            var lista = new List<MEstLaboratorioRecurrente>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EstLaboratoriosMasRecurrentes", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", parametros.FechaInicial);
                    cmd.Parameters.AddWithValue("@Fecha_Final", parametros.FechaFinal);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEstLaboratorioRecurrente = new MEstLaboratorioRecurrente();
                            mEstLaboratorioRecurrente.Codigo_Laboratorio = (int)item["Codigo_Laboratorio"];
                            mEstLaboratorioRecurrente.Nombre = (string)item["Nombre"];
                            mEstLaboratorioRecurrente.Cantidad_Pedidos = (int)item["Cantidad_Pedidos"];

                            lista.Add(mEstLaboratorioRecurrente);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MEstLaboratorioRecurrente>> EstLaboratoriosMenosRecurrentes(MEstadisticas parametros)
        {
            var lista = new List<MEstLaboratorioRecurrente>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EstLaboratoriosMenosRecurrentes", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", parametros.FechaInicial);
                    cmd.Parameters.AddWithValue("@Fecha_Final", parametros.FechaFinal);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEstLaboratorioRecurrente = new MEstLaboratorioRecurrente();
                            mEstLaboratorioRecurrente.Codigo_Laboratorio = (int)item["Codigo_Laboratorio"];
                            mEstLaboratorioRecurrente.Nombre = (string)item["Nombre"];
                            mEstLaboratorioRecurrente.Cantidad_Pedidos = (int)item["Cantidad_Pedidos"];

                            lista.Add(mEstLaboratorioRecurrente);
                        }
                    }
                }
            }
            return lista;
        }

        //Aqui

        public async Task<List<MEstProductoPedidos>> EstProductosConMasPedidos(MEstadisticas parametros)
        {
            var lista = new List<MEstProductoPedidos>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EstProductosConMasPedidos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", parametros.FechaInicial);
                    cmd.Parameters.AddWithValue("@Fecha_Final", parametros.FechaFinal);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEstProductoPedidos = new MEstProductoPedidos();
                            mEstProductoPedidos.Codigo_Producto = (string)item["Codigo_Producto"];
                            mEstProductoPedidos.Descripcion = (string)item["Descripcion"];
                            mEstProductoPedidos.Tipo_Producto = (string)item["Tipo_Producto"];
                            mEstProductoPedidos.Veces_Pedidas = (int)item["Veces_Pedidas"];

                            lista.Add(mEstProductoPedidos);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MEstProductoPedidos>> EstProductosConMenosPedidos(MEstadisticas parametros)
        {
            var lista = new List<MEstProductoPedidos>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EstProductosConMenosPedidos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", parametros.FechaInicial);
                    cmd.Parameters.AddWithValue("@Fecha_Final", parametros.FechaFinal);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEstProductoPedidos = new MEstProductoPedidos();
                            mEstProductoPedidos.Codigo_Producto = (string)item["Codigo_Producto"];
                            mEstProductoPedidos.Descripcion = (string)item["Descripcion"];
                            mEstProductoPedidos.Tipo_Producto = (string)item["Tipo_Producto"];
                            mEstProductoPedidos.Veces_Pedidas = (int)item["Veces_Pedidas"];

                            lista.Add(mEstProductoPedidos);
                        }
                    }
                }
            }
            return lista;
        }

        //

        public async Task<List<MEstPacienteRecurrente>> EstPacienteMasRecurrente(MEstadisticas parametros)
        {
            var lista = new List<MEstPacienteRecurrente>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EstPacientesMasRecurrentes", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", parametros.FechaInicial);
                    cmd.Parameters.AddWithValue("@Fecha_Final", parametros.FechaFinal);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEstPacienteRecurrente = new MEstPacienteRecurrente();
                            mEstPacienteRecurrente.Cliente = (string)item["Cliente"];
                            if (!item.IsDBNull(item.GetOrdinal("Edad")))
                                mEstPacienteRecurrente.Edad = (int)item["Edad"];
                            mEstPacienteRecurrente.Examenes_Realizados = (int)item["Examenes_Realizados"];

                            lista.Add(mEstPacienteRecurrente);
                        }
                    }
                }
            }
            return lista;
        }

        //

        public async Task<List<MEstEdadesRecurrente>> EstEdadesMasRecurrentesEnExamenes(MEstadisticas parametros)
        {
            var lista = new List<MEstEdadesRecurrente>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EstEdadesMasRecurrentesEnExamenes", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", parametros.FechaInicial);
                    cmd.Parameters.AddWithValue("@Fecha_Final", parametros.FechaFinal);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEstEdadesRecurrente = new MEstEdadesRecurrente();
                            mEstEdadesRecurrente.Edad = (int)item["Edad"];
                            mEstEdadesRecurrente.Cantidad_Pacientes = (int)item["Cantidad_Pacientes"];

                            lista.Add(mEstEdadesRecurrente);
                        }
                    }
                }
            }
            return lista;
        }

        //

        public async Task<List<MEstTipoPagoPreferido>> EstTipoPagoPreferido(MEstadisticas parametros)
        {
            var lista = new List<MEstTipoPagoPreferido>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EstTipoPagoPreferido", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", parametros.FechaInicial);
                    cmd.Parameters.AddWithValue("@Fecha_Final", parametros.FechaFinal);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEstTipoPagoPreferido = new MEstTipoPagoPreferido();
                            mEstTipoPagoPreferido.Tipo_Pago = (string)item["Tipo_Pago"];
                            mEstTipoPagoPreferido.Frecuencia_de_uso = (int)item["Frecuencia_de_uso"];

                            lista.Add(mEstTipoPagoPreferido);
                        }
                    }
                }
            }
            return lista;
        }

        //

        public async Task<List<MEstEmpleadoFactura>> EstEmpleadosConMasFacturas(MEstadisticas parametros)
        {
            var lista = new List<MEstEmpleadoFactura>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EstEmpleadosConMasFacturas", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", parametros.FechaInicial);
                    cmd.Parameters.AddWithValue("@Fecha_Final", parametros.FechaFinal);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEstEmpleadoFactura = new MEstEmpleadoFactura();
                            mEstEmpleadoFactura.Numero_Empleado = (int)item["Numero_Empleado"];
                            mEstEmpleadoFactura.Empleado = (string)item["Empleado"];
                            mEstEmpleadoFactura.Facturas_Emitidas = (int)item["Facturas_Emitidas"];

                            lista.Add(mEstEmpleadoFactura);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MEstEmpleadoExamen>> EstEmpleadosConMasExamenes(MEstadisticas parametros)
        {
            var lista = new List<MEstEmpleadoExamen>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EstEmpleadosConMasExamenes", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", parametros.FechaInicial);
                    cmd.Parameters.AddWithValue("@Fecha_Final", parametros.FechaFinal);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEstEmpleadoExamen = new MEstEmpleadoExamen();
                            mEstEmpleadoExamen.Numero_Empleado = (int)item["Numero_Empleado"];
                            mEstEmpleadoExamen.Empleado = (string)item["Empleado"];
                            mEstEmpleadoExamen.Examenes_Realizados = (int)item["Examenes_Realizados"];

                            lista.Add(mEstEmpleadoExamen);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MEstEmpleadoOrdenes>> EstEmpleadosConMasOrdenes(MEstadisticas parametros)
        {
            var lista = new List<MEstEmpleadoOrdenes>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EstEmpleadosConMasOrdenes", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", parametros.FechaInicial);
                    cmd.Parameters.AddWithValue("@Fecha_Final", parametros.FechaFinal);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEstEmpleadoOrdenes = new MEstEmpleadoOrdenes();
                            mEstEmpleadoOrdenes.Numero_Empleado = (int)item["Numero_Empleado"];
                            mEstEmpleadoOrdenes.Empleado = (string)item["Empleado"];
                            mEstEmpleadoOrdenes.Pedidos_Realizados = (int)item["Pedidos_Realizados"];

                            lista.Add(mEstEmpleadoOrdenes);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MEstRolesFrecuentes>> EstRolesMasFrecuentes()
        {
            var lista = new List<MEstRolesFrecuentes>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EstRolesMasFrecuentes", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEstRolesFrecuentes = new MEstRolesFrecuentes();
                            mEstRolesFrecuentes.Rol = (string)item["Rol"];
                            mEstRolesFrecuentes.Descripcion = (string)item["Descripcion"];
                            mEstRolesFrecuentes.Cantidad_Usuarios = (int)item["Cantidad_Usuarios"];

                            lista.Add(mEstRolesFrecuentes);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MEstIngresosVsGastos>> EstSP_EstIngresosVsGastos(MEstadisticas parametros)
        {
            var lista = new List<MEstIngresosVsGastos>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EstIngresosVsGastos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", parametros.FechaInicial);
                    cmd.Parameters.AddWithValue("@Fecha_Final", parametros.FechaFinal);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEstIngresosVsGastos = new MEstIngresosVsGastos();
                            mEstIngresosVsGastos.Codigo_Producto = (string)item["Codigo_Producto"];
                            mEstIngresosVsGastos.Descripcion = (string)item["Descripcion"];
                            mEstIngresosVsGastos.Tipo_Producto = (string)item["Tipo_Producto"];
                            mEstIngresosVsGastos.Cantidad_Actual = (int)item["Cantidad_Actual"];
                            mEstIngresosVsGastos.Cantidades_Vendidas = (int)item["Cantidades_Vendidas"];
                            mEstIngresosVsGastos.Costo_Venta = (decimal)item["Costo_Venta"];
                            mEstIngresosVsGastos.Total_Vendido = (decimal)item["Total_Vendido"];
                            mEstIngresosVsGastos.Cantidad_Obtenida = (int)item["Cantidad_Obtenida"];
                            mEstIngresosVsGastos.Costo_Obtencion = (decimal)item["Costo_Obtencion"];
                            mEstIngresosVsGastos.Cantidad_Pedidos = (int)item["Cantidad_Pedidos"];
                            mEstIngresosVsGastos.Costo_Pedido = (decimal)item["Costo_Pedido"];
                            mEstIngresosVsGastos.Costo_Total = (decimal)item["Costo_Total"];
                            mEstIngresosVsGastos.Beneficios = (decimal)item["Beneficios"];

                            lista.Add(mEstIngresosVsGastos);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MEstIngresosVsGastosTotal>> EstSP_EstIngresosVsGastosTotal(MEstadisticas parametros)
        {
            var lista = new List<MEstIngresosVsGastosTotal>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EstIngresosVsGastosTotal", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", parametros.FechaInicial);
                    cmd.Parameters.AddWithValue("@Fecha_Final", parametros.FechaFinal);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEstIngresosVsGastos = new MEstIngresosVsGastosTotal();
                            mEstIngresosVsGastos.Cantidades_Vendidas = (int)item["Cantidades_Vendidas"];
                            mEstIngresosVsGastos.Costo_Venta = (decimal)item["Costo_Venta"];
                            mEstIngresosVsGastos.Total_Vendido = (decimal)item["Total_Vendido"];
                            mEstIngresosVsGastos.Cantidad_Obtenida = (int)item["Cantidad_Obtenida"];
                            mEstIngresosVsGastos.Costo_Obtencion = (decimal)item["Costo_Obtencion"];
                            mEstIngresosVsGastos.Cantidad_Pedidos = (int)item["Cantidad_Pedidos"];
                            mEstIngresosVsGastos.Costo_Pedido = (decimal)item["Costo_Pedido"];
                            mEstIngresosVsGastos.Costo_Total = (decimal)item["Costo_Total"];
                            mEstIngresosVsGastos.Beneficios = (decimal)item["Beneficios"];

                            lista.Add(mEstIngresosVsGastos);
                        }
                    }
                }
            }
            return lista;
        }

        //
        public async Task<List<MEstProductoVendidoPorTipo>> EstProductosMasVendidosPorTipo(MEstadisticasIngresoProductoTipo parametros)
        {
            var lista = new List<MEstProductoVendidoPorTipo>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EstProductosMasVendidosPorTipo", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", parametros.FechaInicial);
                    cmd.Parameters.AddWithValue("@Fecha_Final", parametros.FechaFinal);
                    cmd.Parameters.AddWithValue("@Tipo_Producto", parametros.Tipo_Producto);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEstProductoVendido = new MEstProductoVendidoPorTipo();
                            mEstProductoVendido.Codigo_Producto = (string)item["Codigo_Producto"];
                            mEstProductoVendido.Descripcion = (string)item["Descripcion"];
                            mEstProductoVendido.Total = (int)item["Total"];

                            lista.Add(mEstProductoVendido);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MEstProductoVendidoPorTipo>> EstProductosMenosVendidosPorTipo(MEstadisticasIngresoProductoTipo parametros)
        {
            var lista = new List<MEstProductoVendidoPorTipo>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_EstProductosMenosVendidosPorTipo", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", parametros.FechaInicial);
                    cmd.Parameters.AddWithValue("@Fecha_Final", parametros.FechaFinal);
                    cmd.Parameters.AddWithValue("@Tipo_Producto", parametros.Tipo_Producto);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEstProductoVendido = new MEstProductoVendidoPorTipo();
                            mEstProductoVendido.Codigo_Producto = (string)item["Codigo_Producto"];
                            mEstProductoVendido.Descripcion = (string)item["Descripcion"];
                            mEstProductoVendido.Total = (int)item["Total"];

                            lista.Add(mEstProductoVendido);
                        }
                    }
                }
            }
            return lista;
        }

    }
}
