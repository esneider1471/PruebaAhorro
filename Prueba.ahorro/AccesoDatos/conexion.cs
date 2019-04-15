using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    class Conexion
    {
        // <connectionStrings>
        //<add name = "strConexion" connectionString="Data Source=.;Initial Catalog=Prueba;User ID=desarrollo;Password=desarrollo" providerName="System.Data.SqlClient" />
        //</connectionStrings>
        readonly string Cadena;

        SqlConnection conexion;
        SqlCommand comando;
        SqlDataAdapter adapter;
        DataTable dataTable;


        internal Conexion()
        {
            Cadena = ConfigurationManager.ConnectionStrings["strConexion"].ConnectionString;
        }
        internal void EjecutarStoredProcedure(string nombreSp, Dictionary<string, object> parametros)
        {
            try
            {
                using (conexion = new SqlConnection(Cadena))
                {
                    //cnn.Open();
                    using (comando = conexion.CreateCommand())
                    {
                        conexion.Open();
                        comando.CommandText = nombreSp;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.CommandTimeout = 9000000;
                        if (parametros != null)
                        {
                            //parametros para el sp
                            foreach (var item in parametros)
                            {
                                //se agrega el parametro que se tiene en el key en la posicion del parametro
                                comando.Parameters.AddWithValue(item.Key, item.Value);
                            }
                        }
                        comando.ExecuteNonQuery();
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        internal DataTable EjecutarStoredProcedureDT(string nombreSp, Dictionary<string, object> parametros)
        {
            dataTable = new DataTable();

            try
            {
                using (conexion = new SqlConnection(Cadena))
                {
                    //cnn.Open();
                    using (comando = conexion.CreateCommand())
                    {
                        conexion.Open();
                        comando.CommandText = nombreSp;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.CommandTimeout = 9000000;
                        if (parametros != null)
                        {
                            //parametros para el sp
                            foreach (var item in parametros)
                            {
                                //se agrega el parametro que se tiene en el key en la posicion del parametro
                                comando.Parameters.AddWithValue(item.Key, item.Value);
                            }
                        }

                        using (adapter = new SqlDataAdapter(comando))
                        {
                            adapter.Fill(dataTable);
                        }

                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return dataTable;
        }
    }
}