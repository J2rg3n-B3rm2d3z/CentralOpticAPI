using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DCorreoEmpleado
    {
        ConexionBD cn = new ConexionBD();
        //public async Task<List<MCorreoEmpleado>> MostrarCorreoEmpleado()
        //{
        //    var lista = new List<MCorreoEmpleado>();
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_mostrarCorreoEmpleado", sql))
        //        {
        //            await sql.OpenAsync();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            using (var item = await cmd.ExecuteReaderAsync())
        //            {
        //                while (await item.ReadAsync())
        //                {
        //                    var mEmpleadoCorreoEmpleado = new MCorreoEmpleado();
        //                    mEmpleadoCorreoEmpleado.IdCorreoEmpleado = (int)item["IdCorreoEmpleado"];
        //                    mEmpleadoCorreoEmpleado.NumEmpleado = (int)item["NumEmpleado"];
        //                    mEmpleadoCorreoEmpleado.Correo = (string)item["Correo"];
        //                    lista.Add(mEmpleadoCorreoEmpleado);
        //                }
        //            }
        //        }
        //    }
        //    return lista;
        //}

        public async Task InsertarCorreoEmpleado(MCorreoEmpleado parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarCorreoEmpleado", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Numero_Empleado", parametros.NumEmpleado);
                    cmd.Parameters.AddWithValue("@Correo", parametros.CorreoNuevo);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarCorreoEmpleado(MCorreoEmpleado parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarCorreoEmpleado", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Numero_Empleado", parametros.NumEmpleado);
                    cmd.Parameters.AddWithValue("@CorreoAnt", parametros.CorreoAnterior);
                    cmd.Parameters.AddWithValue("@CorreoNue", parametros.CorreoNuevo);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        //public async Task EliminarCorreoEmpleado(MCorreoEmpleado parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_eliminarCorreoEmpleado", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@IdCorreoEmpleado", parametros.IdCorreoEmpleado);
        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}
    }
}
