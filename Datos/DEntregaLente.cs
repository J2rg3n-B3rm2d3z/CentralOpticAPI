using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;
using CentralOpticAPI.Controladores;

namespace CentralOpticAPI.Datos
{
    public class DEntregaLente
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MEntregaLente>> MostrarEntregas()
        {
            var lista = new List<MEntregaLente>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarEntregaLente", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mentrega = new MEntregaLente();
                            mentrega.Codigo_Entrega = (int)item["Codigo_Entrega"];
                            mentrega.Fecha_Obtencion = (DateTime)item["Fecha_Obtencion"];
                            mentrega.Numero_Orden = (int)item["Numero_Orden"];
                            mentrega.Fecha_Emision_Orden = (DateTime)item["Fecha_Emision_Orden"];
                            mentrega.Numero_Examen = (int)item["Numero_Examen"];
                            mentrega.Paciente = (string)item["Paciente"];
                            mentrega.Laboratorio = (string)item["Laboratorio"];
                            mentrega.Codigo_Producto = (string)item["Codigo_Producto"];
                            mentrega.Descripcion_Producto = (string)item["Descripcion_Producto"];
                            mentrega.Estado = (bool)item["Estado"];
                            if (!item.IsDBNull(item.GetOrdinal("Observacion_Entrega")))
                                mentrega.Observacion_Entrega = (string)item["Observacion_Entrega"];
                            lista.Add(mentrega);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MEntregaLente>> MostrarEntregasById(MEntregaLente parametros)
        {
            var lista = new List<MEntregaLente>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarEntregaLenteById", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CodigoEntrega", parametros.Codigo_Entrega);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mentrega = new MEntregaLente();
                            mentrega.Codigo_Entrega = (int)item["Codigo_Entrega"];
                            mentrega.Fecha_Obtencion = (DateTime)item["Fecha_Obtencion"];
                            mentrega.Numero_Orden = (int)item["Numero_Orden"];
                            mentrega.Fecha_Emision_Orden = (DateTime)item["Fecha_Emision_Orden"];
                            mentrega.Numero_Examen = (int)item["Numero_Examen"];
                            mentrega.Paciente = (string)item["Paciente"];
                            mentrega.Laboratorio = (string)item["Laboratorio"];
                            mentrega.Codigo_Producto = (string)item["Codigo_Producto"];
                            mentrega.Descripcion_Producto = (string)item["Descripcion_Producto"];
                            mentrega.Estado = (bool)item["Estado"];
                            if (!item.IsDBNull(item.GetOrdinal("Observacion_Entrega")))
                                mentrega.Observacion_Entrega = (string)item["Observacion_Entrega"];
                            lista.Add(mentrega);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MEntregaLente>> MostrarEntregasByOrden(MEntregaLente parametros)
        {
            var lista = new List<MEntregaLente>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarEntregaLentePorOrden", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NumeroOrden", parametros.Numero_Orden);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mentrega = new MEntregaLente();
                            mentrega.Codigo_Entrega = (int)item["Codigo_Entrega"];
                            mentrega.Fecha_Obtencion = (DateTime)item["Fecha_Obtencion"];
                            mentrega.Numero_Orden = (int)item["Numero_Orden"];
                            mentrega.Fecha_Emision_Orden = (DateTime)item["Fecha_Emision_Orden"];
                            mentrega.Numero_Examen = (int)item["Numero_Examen"];
                            mentrega.Paciente = (string)item["Paciente"];
                            mentrega.Laboratorio = (string)item["Laboratorio"];
                            mentrega.Codigo_Producto = (string)item["Codigo_Producto"];
                            mentrega.Descripcion_Producto = (string)item["Descripcion_Producto"];
                            mentrega.Estado = (bool)item["Estado"];
                            if (!item.IsDBNull(item.GetOrdinal("Observacion_Entrega")))
                                mentrega.Observacion_Entrega = (string)item["Observacion_Entrega"];
                            lista.Add(mentrega);
                        }
                    }
                }
            }
            return lista;
        }


        public async Task<List<MEntregaLente>> MostrarEntregasValidas(MEntregaLente parametros)
        {
            var lista = new List<MEntregaLente>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarEntregaLenteValido", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Estado", parametros.Estado);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mentrega = new MEntregaLente();
                            mentrega.Codigo_Entrega = (int)item["Codigo_Entrega"];
                            mentrega.Fecha_Obtencion = (DateTime)item["Fecha_Obtencion"];
                            mentrega.Numero_Orden = (int)item["Numero_Orden"];
                            mentrega.Fecha_Emision_Orden = (DateTime)item["Fecha_Emision_Orden"];
                            mentrega.Numero_Examen = (int)item["Numero_Examen"];
                            mentrega.Paciente = (string)item["Paciente"];
                            mentrega.Laboratorio = (string)item["Laboratorio"];
                            mentrega.Codigo_Producto = (string)item["Codigo_Producto"];
                            mentrega.Descripcion_Producto = (string)item["Descripcion_Producto"];
                            mentrega.Estado = (bool)item["Estado"];
                            if (!item.IsDBNull(item.GetOrdinal("Observacion_Entrega")))
                                mentrega.Observacion_Entrega = (string)item["Observacion_Entrega"];
                            lista.Add(mentrega);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarEntrega(MEntregaLente parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarEntregaLente", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Numero_Orden", parametros.Numero_Orden);
                    cmd.Parameters.AddWithValue("@Fecha_Obtencion", parametros.Fecha_Obtencion);
                    cmd.Parameters.AddWithValue("@Observacion", SqlDbType.NVarChar).Value = (object)parametros.Observacion_Entrega ?? DBNull.Value;

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarEntrega(MEntregaLente parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarEstadoEntregaLente", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Codigo_Entrega", parametros.Codigo_Entrega);
                    cmd.Parameters.AddWithValue("@Estado", parametros.Estado);
                    cmd.Parameters.AddWithValue("@Observacion", SqlDbType.NVarChar).Value = (object)parametros.Observacion_Entrega ?? DBNull.Value;

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        //public async Task EliminarEntrega(MEntregaLente parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_eliminarEntrega", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@CodEntrega", parametros.CodEntrega);
        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}

    }
}
