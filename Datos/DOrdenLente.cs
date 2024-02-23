using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DOrdenLente
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MOrdenLente>> MostrarOrdenLente()
        {
            var lista = new List<MOrdenLente>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarOrdenLente", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mordenpedido = new MOrdenLente();
                            mordenpedido.Numero_Orden = (int)item["Numero_Orden"];
                            mordenpedido.Fecha_Emision = (DateTime)item["Fecha_Emision"];
                            mordenpedido.Empleado_Emisor = (string)item["Empleado_Emisor"];
                            mordenpedido.Numero_Examen = (int)item["Numero_Examen"];
                            mordenpedido.Fecha_Examen = (DateTime)item["Fecha_Examen"];
                            mordenpedido.Paciente = (string)item["Paciente"];
                            mordenpedido.Laboratorio = (string)item["Laboratorio"];
                            mordenpedido.Codigo_Producto = (string)item["Codigo_Producto"];
                            mordenpedido.Descripcion_Producto = (string)item["Descripcion_Producto"];
                            mordenpedido.Estado_OrdenLente = (string)item["Estado_OrdenLente"];
                            mordenpedido.Costo = (decimal)item["Costo"];
                            if (!item.IsDBNull(item.GetOrdinal("Observacion")))
                                mordenpedido.Observacion = (string)item["Observacion"];
                            
                            lista.Add(mordenpedido);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MOrdenLente>> MostrarOrdenLenteById(MOrdenLente parametros)
        {
            var lista = new List<MOrdenLente>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarOrdenLenteById", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Numero_Orden", parametros.Numero_Orden);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mordenpedido = new MOrdenLente();
                            mordenpedido.Numero_Orden = (int)item["Numero_Orden"];
                            mordenpedido.Fecha_Emision = (DateTime)item["Fecha_Emision"];
                            mordenpedido.Empleado_Emisor = (string)item["Empleado_Emisor"];
                            mordenpedido.Numero_Examen = (int)item["Numero_Examen"];
                            mordenpedido.Fecha_Examen = (DateTime)item["Fecha_Examen"];
                            mordenpedido.Paciente = (string)item["Paciente"];
                            mordenpedido.Laboratorio = (string)item["Laboratorio"];
                            mordenpedido.Codigo_Producto = (string)item["Codigo_Producto"];
                            mordenpedido.Descripcion_Producto = (string)item["Descripcion_Producto"];
                            mordenpedido.Estado_OrdenLente = (string)item["Estado_OrdenLente"];
                            mordenpedido.Costo = (decimal)item["Costo"];
                            if (!item.IsDBNull(item.GetOrdinal("Observacion")))
                                mordenpedido.Observacion = (string)item["Observacion"];

                            lista.Add(mordenpedido);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MOrdenLente>> MostrarOrdenLenteValido(bool Estado)
        {
            var lista = new List<MOrdenLente>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarOrdenLenteValido", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Valido", Estado);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mordenpedido = new MOrdenLente();
                            mordenpedido.Numero_Orden = (int)item["Numero_Orden"];
                            mordenpedido.Fecha_Emision = (DateTime)item["Fecha_Emision"];
                            mordenpedido.Empleado_Emisor = (string)item["Empleado_Emisor"];
                            mordenpedido.Numero_Examen = (int)item["Numero_Examen"];
                            mordenpedido.Fecha_Examen = (DateTime)item["Fecha_Examen"];
                            mordenpedido.Paciente = (string)item["Paciente"];
                            mordenpedido.Laboratorio = (string)item["Laboratorio"];
                            mordenpedido.Codigo_Producto = (string)item["Codigo_Producto"];
                            mordenpedido.Descripcion_Producto = (string)item["Descripcion_Producto"];
                            mordenpedido.Estado_OrdenLente = (string)item["Estado_OrdenLente"];
                            mordenpedido.Costo = (decimal)item["Costo"];
                            if (!item.IsDBNull(item.GetOrdinal("Observacion")))
                                mordenpedido.Observacion = (string)item["Observacion"];

                            lista.Add(mordenpedido);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarOrdenLente(MOrdenLenteIngreso parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarOrdenLente", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Numero_Examen", parametros.Numero_Examen);
                    cmd.Parameters.AddWithValue("@Numero_Empleado", parametros.Numero_Empleado);
                    cmd.Parameters.AddWithValue("@Laboratorio", parametros.Laboratorio);
                    cmd.Parameters.AddWithValue("@Descripcion_Producto", parametros.Descripcion_Producto);
                    cmd.Parameters.AddWithValue("@Fecha_Emision", parametros.Fecha_Emision);
                    cmd.Parameters.AddWithValue("@Costo", parametros.Costo);
                   
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarOrdenPedido(MOrdenLente parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarEstadoOrden", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Numero_Orden", parametros.Numero_Orden);
                    cmd.Parameters.AddWithValue("@Estado_OrdenLente", parametros.Estado_OrdenLente);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        //public async Task EliminarOrdenPedido(MOrdenLente parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_eliminarOrdenPedido", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@NumOrden", parametros.NumOrden);
        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}
    }
}
