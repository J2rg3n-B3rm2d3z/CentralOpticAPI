using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;
using CentralOpticAPI.Controladores;

namespace CentralOpticAPI.Datos
{
    public class DEmpleado
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MEmpleado>> MostrarEmpleado()
        {
            var lista = new List<MEmpleado>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarEmpleados", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEmpleado = new MEmpleado();
                            mEmpleado.NumEmpleado = (int)item["Numero_Empleado"];
                            mEmpleado.Cedula = (string)item["Cedula"];
                            mEmpleado.Nombres = (string)item["Nombres"];
                            mEmpleado.Apellidos = (string)item["Apellidos"];
                            mEmpleado.Direccion = (string)item["Direccion"];
                            mEmpleado.FechaNac = (DateTime)item["Fecha_Nacimiento"];
                            mEmpleado.Edad = (int)item["Edad"];
                            if (!item.IsDBNull(item.GetOrdinal("Telefonos")))
                                mEmpleado.Telefonos = (string)item["Telefonos"];
                            if (!item.IsDBNull(item.GetOrdinal("Correos")))
                                mEmpleado.Correos = (string)item["Correos"];
                            mEmpleado.Estado = (bool)item["Estado"];
                            lista.Add(mEmpleado);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MEmpleado>> MostrarEmpleadoById(MEmpleado parametros)
        {
            var lista = new List<MEmpleado>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarEmpleadosById", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Numero_Empleado", parametros.NumEmpleado);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEmpleado = new MEmpleado();
                            mEmpleado.NumEmpleado = (int)item["Numero_Empleado"];
                            mEmpleado.Cedula = (string)item["Cedula"];
                            mEmpleado.Nombres = (string)item["Nombres"];
                            mEmpleado.Apellidos = (string)item["Apellidos"];
                            mEmpleado.Direccion = (string)item["Direccion"];
                            mEmpleado.FechaNac = (DateTime)item["Fecha_Nacimiento"];
                            mEmpleado.Edad = (int)item["Edad"];
                            if (!item.IsDBNull(item.GetOrdinal("Telefonos")))
                                mEmpleado.Telefonos = (string)item["Telefonos"];
                            if (!item.IsDBNull(item.GetOrdinal("Correos")))
                                mEmpleado.Correos = (string)item["Correos"];
                            mEmpleado.Estado = (bool)item["Estado"];
                            lista.Add(mEmpleado);
                        }
                    }
                }
            }
            return lista;
        }

        //public async Task InsertarEmpleado(MEmpleado parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_insertarEmpleado", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@Nombres", parametros.Nombres);
        //            cmd.Parameters.AddWithValue("@Apellidos", parametros.Apellidos);
        //            cmd.Parameters.AddWithValue("@Direccion", parametros.Direccion);

        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}

        //public async Task EditarEmpleado(MEmpleado parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_editarEmpleado", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@NumEmpleado", parametros.NumEmpleado);
        //            cmd.Parameters.AddWithValue("@Nombres", parametros.Nombres);
        //            cmd.Parameters.AddWithValue("@Apellidos", parametros.Apellidos);
        //            cmd.Parameters.AddWithValue("@Direccion", parametros.Direccion);

        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}

        //public async Task EliminarEmpleado(MEmpleado parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_eliminarEmpleado", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@NumEmpleado", parametros.NumEmpleado);
        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}

    }
}

