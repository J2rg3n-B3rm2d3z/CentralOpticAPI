using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DTelefonoEmpleado
    {
        ConexionBD cn = new ConexionBD();
        //public async Task<List<MTelefonoEmpleado>> MostrarTelefonoEmpleado()
        //{
        //    var lista = new List<MTelefonoEmpleado>();
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_mostrarTelefonoEmpleado", sql))
        //        {
        //            await sql.OpenAsync();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            using (var item = await cmd.ExecuteReaderAsync())
        //            {
        //                while (await item.ReadAsync())
        //                {
        //                    var mEmpleadoTelefonoEmpleado = new MTelefonoEmpleado();
        //                    mEmpleadoTelefonoEmpleado.IdTelefonoEmpleado = (int)item["IdTelefonoEmpleado"];
        //                    mEmpleadoTelefonoEmpleado.NumEmpleado = (int)item["NumEmpleado"];
        //                    mEmpleadoTelefonoEmpleado.Telefono = (string)item["Telefono"];
        //                    lista.Add(mEmpleadoTelefonoEmpleado);
        //                }
        //            }
        //        }
        //    }
        //    return lista;
        //}

        public async Task InsertarTelefonoEmpleado(MTelefonoEmpleado parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarTelefonoEmpleado", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Numero_Empleado", parametros.NumEmpleado);
                    cmd.Parameters.AddWithValue("@Telefono", parametros.TelefonoNuevo);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarTelefonoEmpleado(MTelefonoEmpleado parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarTelefonoEmpleado", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Numero_Empleado", parametros.NumEmpleado);
                    cmd.Parameters.AddWithValue("@TelefonoAnt", parametros.TelefonoAnterior);
                    cmd.Parameters.AddWithValue("@TelefonoNue", parametros.TelefonoNuevo);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        //public async Task EliminarTelefonoEmpleado(MTelefonoEmpleado parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_eliminarTelefonoEmpleado", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@IdTelefonoEmpleado", parametros.IdTelefonoEmpleado);
        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}
    }
}
