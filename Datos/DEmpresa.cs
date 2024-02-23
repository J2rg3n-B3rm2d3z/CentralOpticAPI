using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DEmpresa
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MEmpresa>> MostrarEmpresa()
        {
            var lista = new List<MEmpresa>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarEmpresa", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEmpresa = new MEmpresa();
                            mEmpresa.Id_Empresa = (int)item["Id_Empresa"];
                            mEmpresa.Nombre = (string)item["Nombre"];
                            mEmpresa.Numero_Ruc = (string)item["Numero_Ruc"];
                            lista.Add(mEmpresa);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MEmpresa>> MostrarEmpresaById(MEmpresa parametros)
        {
            var lista = new List<MEmpresa>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarEmpresaById", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Empresa", parametros.Id_Empresa);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mEmpresa = new MEmpresa();
                            mEmpresa.Id_Empresa = (int)item["Id_Empresa"];
                            mEmpresa.Nombre = (string)item["Nombre"];
                            mEmpresa.Numero_Ruc = (string)item["Numero_Ruc"];
                            lista.Add(mEmpresa);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarEmpresa(MEmpresa parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarEmpresa", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Numero_Ruc", parametros.Numero_Ruc);
                    cmd.Parameters.AddWithValue("@Nombre", parametros.Nombre);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
        public async Task EditarEmpresa(MEmpresa parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarEmpresa", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id_Empresa", parametros.Id_Empresa);
                    cmd.Parameters.AddWithValue("@Numero_Ruc", parametros.Numero_Ruc);
                    cmd.Parameters.AddWithValue("@Nombre", parametros.Nombre);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

    }
}
