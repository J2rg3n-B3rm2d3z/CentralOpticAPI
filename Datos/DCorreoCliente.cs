using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DCorreoCliente
    {
        ConexionBD cn = new ConexionBD();

        //public async Task<List<MCorreoCliente>> MostrarCorreoClientes()
        //{
        //    var lista = new List<MCorreoCliente>();
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_mostrarCorreoCliente", sql))
        //        {
        //            await sql.OpenAsync();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            using (var item = await cmd.ExecuteReaderAsync())
        //            {
        //                while (await item.ReadAsync())
        //                {
        //                    var mcorreocliente = new MCorreoCliente();
        //                    mcorreocliente.IdCorreoCliente = (int)item["IdCorreoCliente"];
        //                    mcorreocliente.CodCliente = (int)item["CodCliente"];
        //                    mcorreocliente.Correo = (string)item["Correo"];
        //                    lista.Add(mcorreocliente);
        //                }
        //            }
        //        }
        //    }
        //    return lista;
        //}

        public async Task InsertarCorreoCliente(MCorreoCliente parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarCorreoCliente", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo_Cliente", parametros.Codigo_Cliente);
                    cmd.Parameters.AddWithValue("@Correo", parametros.CorreoNuevo);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarCorreoCliente(MCorreoCliente parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarCorreoCliente", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Codigo_Cliente", parametros.Codigo_Cliente);
                    cmd.Parameters.AddWithValue("@CorreoAnt", parametros.CorreoAnterior);
                    cmd.Parameters.AddWithValue("@CorreoNue", parametros.CorreoNuevo);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        //public async Task EliminarCorreoCliente(MCorreoCliente parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_eliminarCorreoCliente", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@IdCorreoCliente", parametros.IdCorreoCliente);
        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}
    }
}
