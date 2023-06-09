﻿using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DUsuario
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MUsuario>> MostrarUsuarios()
        {
            var lista = new List<MUsuario>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarUsuarios", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var musuario = new MUsuario();
                            musuario.IdUsuario = (int)item["IdUsuario"];
                            musuario.NombreUsuario = (string)item["NombreUsuario"];
                            musuario.Clave = (string)item["Clave"];
                            musuario.Correo = (string)item["Correo"];
                            musuario.Rol = (string)item["Rol"];
                            musuario.Nombres = (string)item["Nombres"];
                            musuario.Apellidos = (string)item["Apellidos"];

                            //byte[] clave = Convert.FromBase64String(musuario.Clave);
                            //musuario.Clave = System.Text.Encoding.UTF8.GetString(clave);

                            lista.Add(musuario);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarUsuario(MUsuario parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarUsuario", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreUsuario", parametros.NombreUsuario);
                    cmd.Parameters.AddWithValue("@Clave", parametros.Clave);
                    cmd.Parameters.AddWithValue("@Correo", parametros.Correo);
                    cmd.Parameters.AddWithValue("@Rol", parametros.Rol);
                    cmd.Parameters.AddWithValue("@Nombres", parametros.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", parametros.Apellidos);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
        public async Task EditarUsuario(MUsuario parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarUsuario", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@IdUsuario", parametros.IdUsuario);
                    cmd.Parameters.AddWithValue("@NombreUsuario", parametros.NombreUsuario);
                    cmd.Parameters.AddWithValue("@Clave", parametros.Clave);
                    cmd.Parameters.AddWithValue("@Correo", parametros.Correo);
                    cmd.Parameters.AddWithValue("@Rol", parametros.Rol);
                    cmd.Parameters.AddWithValue("@Nombres", parametros.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", parametros.Apellidos);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarUsuario(MUsuario parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_eliminarUsuario", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdUsuario", parametros.IdUsuario);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

    }
}
