using Entidades.Barrios;
using Entidades.Resultados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AccesoDatos.Barrios
{
   public class BarriosDat
    {
        public ResultadosEnt CrearBarrio(BarriosEnt barriosEnt) {
            ResultadosEnt Respuesta = new ResultadosEnt();

            try
            {
                Conexion dbconexion = new Conexion();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("NomBarrio", barriosEnt.NomBarrio);
                parametros.Add("ciudad", barriosEnt.Ciudad);

                dbconexion.EjecutarStoredProcedure("InsertarBarrio", parametros);
                Respuesta.Resultado = 1;

            }
            catch (Exception ex)
            {
                Respuesta.Resultado = 0;
                throw ex;
            }
            return Respuesta;
        
         }
        public List<BarriosEnt> ListarBarrios()
        {
            List<BarriosEnt> ListaBarrios = new List<BarriosEnt>();
            Conexion dbConexion = new Conexion();

            try
            {
                using (DataTable datos = dbConexion.EjecutarStoredProcedureDT("ConsultarBarrio", null))
                {
                    if (datos.Rows.Count > 0) {
                        ListaBarrios = (from item in datos.AsEnumerable()
                                        select new BarriosEnt
                                        {
                                            IdBarrio = (int) item["IdBarrio"],
                                            NomBarrio = item["Nombarrio"].ToString().Trim()
                                        }).ToList();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaBarrios;

        }
    }
   

}
